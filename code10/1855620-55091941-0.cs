using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
class Program
{
	const string CommandTest = @"
SET NOCOUNT ON;
WAITFOR DELAY '00:00:01';
WITH
	L0   AS (SELECT c FROM (SELECT 1 UNION ALL SELECT 1) AS D(c)), -- 2^1
	L1   AS (SELECT 1 AS c FROM L0 AS A CROSS JOIN L0 AS B),       -- 2^2
	L2   AS (SELECT 1 AS c FROM L1 AS A CROSS JOIN L1 AS B),       -- 2^4
	L3   AS (SELECT 1 AS c FROM L2 AS A CROSS JOIN L2 AS B),       -- 2^8
	L4   AS (SELECT 1 AS c FROM L3 AS A CROSS JOIN L3 AS B),       -- 2^16
	L5   AS (SELECT 1 AS c FROM L4 AS A CROSS JOIN L4 AS B),       -- 2^32
	Nums AS (SELECT ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS k FROM L5)
SELECT
	k
FROM
	Nums
WHERE
	k <= 100000";
	const string ConnectionString = "Server=tcp:.;Database=master;Integrated Security=SSPI;";
	const int VirtualClientCount = 100;
	// This requires c# 7.1 or later. Check project settings
	public static async Task Main(string[] args)
	{
		var aSW = new System.Diagnostics.Stopwatch();
		aSW.Restart();
		{
			var aTasks = Enumerable.Range(0, VirtualClientCount).Select(_ => ExecuteWrapperAsync());
			await Task.WhenAll(aTasks);
			Console.WriteLine($"ExecuteWrapperAsync completed in {aSW.Elapsed}.");
		}
		aSW.Restart();
		{
			var aTasks = Enumerable.Range(0, VirtualClientCount).Select(_ => ExecuteNativeAsync());
			await Task.WhenAll(aTasks);
			Console.WriteLine($"ExecuteNativeAsync  completed in {aSW.Elapsed}.");
		}
	}
	private static Task<long> ExecuteWrapperAsync()
	{
		return Task.Run(() => ExecuteSync());
	}
	private static long ExecuteSync()
	{
		using (var aConn = new SqlConnection(ConnectionString))
		using (var aCmd = new SqlCommand(CommandTest, aConn))
		{
			aConn.Open();
			using (var aR = aCmd.ExecuteReader())
			{
				long aRetVal = 0;
				while (aR.Read())
					aRetVal += aR.GetInt64(0);
				return aRetVal;
			}
		}
	}
	private static async Task<long> ExecuteNativeAsync()
	{
		using (var aConn = new SqlConnection(ConnectionString))
		using (var aCmd = new SqlCommand(CommandTest, aConn))
		{
			await aConn.OpenAsync();
			using (var aR = await aCmd.ExecuteReaderAsync())
			{
				long aRetVal = 0;
				while (await aR.ReadAsync())
					aRetVal += aR.GetInt64(0);
				return aRetVal;
			}
		}
	}
}
Now I'm getting the following output:
ExecuteWrapperAsync completed in 00:00:09.6214859.
ExecuteNativeAsync  completed in 00:00:02.2103956.
Thanks to David Browne for the hint!
