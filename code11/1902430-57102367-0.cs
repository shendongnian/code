cs
namespace ConsoleApp1
{
    public class JgLogDb : DbContext
    {
[...]
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=test.db");
        }
    }
[...]
    class Program
    {
        static async Task Main()
        {
            using (var db = new JgLogDb())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                await db.TabTest1Set.AddAsync(new TabTest1()
                {
                    Feld1 = "Hallo",
                    MTest = new MeinTest()
                    {
                        FeldTest = "Ballo"
                    }
                });
                await db.SaveChangesAsync();
            }
[...]
        }
    }
}
Note, my code is trashing the database (via `EnsureDeleted()`) and recreating it from scratch (via `EnsureCreated()`), so it may be that your existing `SqlExpress` database differs from the model.
That said, I've had similar issues with nested `[Owned]` objects.  It may be worth checking out the [Fluent API for `.ToTable()`][1] as there are currently some limitations to owned entities: https://msdn.microsoft.com/en-us/magazine/mt846463.aspx
  [1]: https://docs.microsoft.com/en-us/ef/core/modeling/relational/tables
