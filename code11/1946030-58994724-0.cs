Inline vars: 00:01:09.7444764
Bound  vars: 00:01:05.4454827
static void Main(string[] args)
{
	var LEN = 30000;
	var cmd = new OracleCommand();
	var sql = "update some_table set progress={0} where id=100";
	var rnd = new Random((int)DateTime.Now.Ticks);
	//
	var sw = new Stopwatch();
	sw.Start();
	for (int i = 0; i < LEN; i++)
	{
		using(var cnn = new OracleConnection("xxx"))
		{
			sql = string.Format(sql, rnd.Next());
			cmd.CommandText = sql;
			cmd.Connection = cnn;
			cnn.Open();
			cmd.ExecuteNonQuery();
		}
	}
	sw.Stop();
	Console.WriteLine("Inline vars: {0}", sw.Elapsed);
	//
	sw.Restart();
	sql = "update tm_fnet set progress=:p where id=:i";
	for (int i = 0; i < LEN; i++)
	{
		using (var cnn = new OracleConnection("xxx"))
		{
			cmd.CommandText = sql;
			cmd.Connection = cnn;
                        cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("i", 100);
			cmd.Parameters.AddWithValue("p", rnd.Next());
			cnn.Open();
			cmd.ExecuteNonQuery();
		}
	}
	sw.Stop();
	Console.WriteLine("Bound vars: {0}", sw.Elapsed);
	//
	Console.ReadKey(false);
}
**Conclusion** - its not that important unless you have to care for SQL injections (*but that's irrelevant in my case*).
