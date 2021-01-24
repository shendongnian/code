    var task2 = Task < List < ActorModel >> .Factory.StartNew(() => {
	var ans = new List < ActorModel > ();
	using(var conn = new SqliteConnection(DB_PATH)) {
	conn.Open();
	using(var cmd = conn.CreateCommand()) {
	cmd.CommandType = CommandType.Text;
	cmd.CommandText =
	"SELECT * FROM actor where Actor.name like @Search";
	cmd.Parameters.Add(new SqliteParameter{
	ParameterName = "Search",
	Value = $ "%{searchString}%"
	});
	var reader = cmd.ExecuteReader();
	while (reader.Read()) {
	var actorModel = new PopulateScrollView.ActorModel{
	Id = reader.GetInt32(0),
	Name = reader.GetString(1),
	ThumbPath = reader.GetString(4),
	Gender = reader.GetInt32(2)
	};
	ans.Add(actorModel);
	}
	}
	}
	onGotActorsFromDbDelegate ? .Invoke(ans);
	return ans;
	});
