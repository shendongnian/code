	void Main()
	{
		var json = @"[
			{
				'Name': 'imi',
				'TeamName': 'csharks'
			},
			{
				'Name': 'romeo',
				'TeamName': 'csharks'
			},
			{
				'Name': 'peti',
				'TeamName': 'csharks'
			},
			{
				'Name': 'berti',
				'TeamName': 'csharks'
			},
			{
				'Name': 'bala',
				'TeamName': 'csharks'
			}]";
			
		var teams = JsonConvert.DeserializeObject<List<Team>>(json);
	
		teams.ForEach(x => Console.WriteLine($"Name: {x.Name}, Team: {x.TeamName}"));
	}
	
	public class Team
	{
		public String Name { get; set; }
		public String TeamName { get; set; }
	}
