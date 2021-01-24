 public async Task<int> ExecuteCommandAsync(string sqlCommand, params object[] parameters)
        {
            return await this.DataContext.Database.ExecuteSqlCommandAsync(sqlCommand, parameters);
        }
Or if you use context directly 
using(var context = new SampleContext())
{
    var commandText = "INSERT Categories (CategoryName) VALUES (@CategoryName)";
    var name = new SqlParameter("@CategoryName", "Test");
 
    context.Database.ExecuteSqlCommand(commandText, name);
    context.SaveChanges();
}
[example][1]
 Using Fluent API to configure entities to turn off cascade delete using the `WillCascadeOnDelete()` 
protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasOptional<Standard>(s => s.Standard)
            .WithMany()
            .WillCascadeOnDelete(false);
    }
  [1]: https://www.learnentityframeworkcore.com/raw-sql
