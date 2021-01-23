    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    class Program
    {
      static void Main()
      {
      string connectionString = GetConnectionString();
      sing (SqlConnection connection = new SqlConnection(connectionString))
      {
       // Connect to the database then retrieve the schema information.
       connection.Open();
       DataTable table = connection.GetSchema("Tables");
    
       // Display the contents of the table.
       DisplayData(table);
       Console.WriteLine("Press any key to continue.");
       Console.ReadKey();
       }
     }
    
      private static string GetConnectionString()
      {
       // To avoid storing the connection string in your code,
       // you can retrieve it from a configuration file.
       return "Data Source=(local);Database=AdventureWorks;" +
          "Integrated Security=true;";
      }
    
      private static void DisplayData(System.Data.DataTable table)
      {
         foreach (System.Data.DataRow row in table.Rows)
         {
            foreach (System.Data.DataColumn col in table.Columns)
            {
               Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);
            }
         Console.WriteLine("============================");
         }
      }
    }
