	using System;
	using System.Data.OleDb;
	namespace TestQindowsSearch
	{
		public class Test
		{
			public static void Main()
			{
				var conn = new OleDbConnection("Provider=Search.CollatorDSO;Extended Properties='Application=Windows';");
				conn.Open();
				OleDbCommand cmd = new OleDbCommand("SELECT Top 10 System.ItemUrl FROM SystemIndex WHERE SCOPE='file:h:/projects/db4o/trunk/db4o.net' AND CONTAINS('IActivatable') AND CONTAINS(System.ItemUrl, '.cs')", conn);
				var result = cmd.ExecuteReader();
				while (result.Read())
				{
					Console.WriteLine(result[0]);
				}
			}
		}
	}
