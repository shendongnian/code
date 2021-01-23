    using System;
    using System.Data;
    
    namespace ConsoleApplication10
    {
      class Program
      {
        static void Main(string[] args)
        {
          var dt = new DataTable();
          dt.Columns.Add("Id", typeof(int));
          dt.Columns.Add("Project Name", typeof(string));
          dt.Columns.Add("Project Date", typeof(DateTime));
    
          for (int i = 0; i < 10; i++)
          {
            var row = dt.NewRow();
            row.ItemArray = new object[] { i, "Title-" + i.ToString(), DateTime.Now.AddDays(i * -1) };
            dt.Rows.Add(row);
          }
    
          var pp = from p in dt.AsEnumerable()
                   where (int)p["Id"] > 2
                   select p;
          foreach (var row in pp)
          {
            Console.WriteLine(row["Id"] + "\t" + row["Project Name"] + "\t" + row["Project Date"]); 
          }
          Console.ReadLine();
        }
      }
    }
