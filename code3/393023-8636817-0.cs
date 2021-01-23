    using System;
    using System.Data;
    
    
    namespace ConsoleApplication5
    {
      class Program
      {    
    
        static void Main(string[] args)
        {
          DataTable dt = new DataTable();
          string col = "Expected closure date";
          dt.Columns.Add(col,typeof(DateTime));
    
          dt.Rows.Add(DateTime.Now.AddDays(-1) );
    
          Console.WriteLine("Total rows in dt " + dt.Rows.Count);
    
          DateTime Tdy = DateTime.Now;
          var rows = dt.Select(string.Format("[Expected closure date] <= '{0}'", Tdy));
          foreach (var row in rows)
            row.Delete();
          Console.WriteLine("Total rows in dt " + dt.Rows.Count);
    
          Console.ReadLine();
         
        }
      }
    }
