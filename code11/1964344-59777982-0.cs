csharp
public class MyInterceptor : DbCommandInterceptor {
    public override InterceptionResult<int> NonQueryExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<int> result) {
        if (ContainsBannedTable(command)) {
            //suppress the operation
            result = InterceptionResult<int>.SuppressWithResult(0);
        }
        return base.NonQueryExecuting(command, eventData, result);
    }
    private bool ContainsBannedTable(DbCommand command) {
        //or custom logic
        return command.CommandText.Contains("ToDeleteEntity");
    }
}
The following will throw an exception (`Microsoft.EntityFrameworkCore.DbUpdateException... SqliteException: SQLite Error 1: 'no such table: ToDeleteEntity'`) when trying to access the undesired table.
csharp
var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();
var options = new DbContextOptionsBuilder<MyContext>()
                  .UseSqlite(connection)
                  .AddInterceptors(new MyInterceptor())
                  .Options
                  ;
var context = new MyContext(options);
context.Database.EnsureCreated();
context.AllowedEntity.Add(new AllowedEntity { Id = 1 });
context.SaveChanges();
Console.WriteLine(context.AllowedEntity.FirstOrDefault()?.Id); //1 - ok
context.ToDeleteEntity.Add(new ToDeleteEntity { Id = 1 });
//will throw an exception
context.SaveChanges();
Console.WriteLine(context.ToDeleteEntity.FirstOrDefault()?.Id);
//close the connection and clean up
//...
csharp
public class MyContext : DbContext {
    public MyContext(DbContextOptions options) : base(options) {
    }
    public DbSet<AllowedEntity> AllowedEntity { get; set; }
    public DbSet<ToDeleteEntity> ToDeleteEntity { get; set; }
}
public class ToDeleteEntity {
    public int Id { get; set; }
}
public class AllowedEntity {
    public int Id { get; set; }
}
