    public interface IDBImplementation
    {
      public void ProcessQuery(Select query);
    }
    public class SqlServerImplementation : IDBImplementation
    {
      public void ProcessQuery(Select query)
      {
        string sqlQuery = "SELECT " + String.Join(", ", query.Columns)
          + " FROM " + query.TableName + " WHERE " + String.Join(" AND ", query.Conditions);
        // execute query...
      }
    }
    public class Select
    {
      public Select(params string[] columns)
      {
        Columns = columns;
      }
      public string[] Columns { get; set; }
      public string TableName { get; set; }
      public string[] Conditions { get; set; }
    }
    public static class Extensions
    {
      public static Select From(this Select select, string tableName)
      {
        select.TableName = tableName;
        return select;
      }
      public static Select Where(this Select select, params string[] conditions)
      {
        select.Conditions = conditions;
        return select;
      }
    }
    public static class Main
    {
      public static void Example()
      {
        IDBImplementation database = new SqlServerImplementation();
        var query = new Select("a", "b", "c").From("test").Where("c>5", "b<10");
        database.ProcessQuery(query);
      }
    }
