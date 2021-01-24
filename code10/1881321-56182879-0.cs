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
}
[example][1]
  [1]: https://www.learnentityframeworkcore.com/raw-sql
