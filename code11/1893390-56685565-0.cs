c#
namespace MyMapper
{
   [Database]
   public class MyDataContext : DataContext
   {
      public MyDataContext() : base(new MySqlConnection(Properties.Settings.Default.myConnectionString)) { }
      public Table<ElementId> ElementIds;
   }
}
but now the following exception is thrown:
You have an error in your SQL syntax; check the manual that corresponds to your MariaDB server version for the right syntax to use near '[ElementId]([IntegerValue])
VALUES (88)' at line 1
it looks that the query is not being formatted as MySQL
