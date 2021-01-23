using System.Linq;
using Dapper;
using Microsoft.EntityFrameworkCore;
public static class DbContextsExtensions
{
	public static bool TableExists(this DbContext dbContext, string tableName)
	{
		var sqlQ = $"SELECT COUNT(*) as Count FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}'";
		var conn = dbContext.Database.GetDbConnection();
		{
			if (conn != null)
			{
				// Query - method extension provided by Dapper library
				var count = conn.Query<int>(sqlQ).FirstOrDefault();
				return (count > 0);                    
			}
		}
		return false;
	}
}
And here is an usage example:
if(context != null && context.TableExists("AppSettings"))
{
   // do something;
}
Hope this help other people.
