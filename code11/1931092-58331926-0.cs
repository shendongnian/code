using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
public class RowLevelSecurityInterceptor : DbCommandInterceptor
{
  public override InterceptionResult<DbDataReader> ReaderExecuting(
    DbCommand command,
    CommandEventData eventData,
    InterceptionResult<DbDataReader> result)
  {
    // command.CommandText += " OPTION (OPTIMIZE FOR UNKNOWN)";
    return result;
  }
}
public class MyDbContext : DbContext
{
  // previous codes
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
      
    optionsBuilder
      .UseNpgsql(GetConnectionString())
      .AddInterceptors(new RowLevelSecurityInterceptor());
    }
  }
}
