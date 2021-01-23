    using System;
    using System.Linq;
    using System.Data.Linq;
    using System.Data;
    
    
        namespace ConsoleApplication5
        {
          class Program
          {
        
            static void Main(string[] args)
            {
              DataSet ds = new DataSet();
              
              DataTable dt = new DataTable();
              ds.Tables.Add(dt);
              string col = "personId";
              dt.Columns.Add(col, typeof(int));
        
              dt.Rows.Add(1);
              dt.Rows.Add(2);
        
              string s = String.Join(", ", ds.Tables[0].Select().Select(r => r["personID"].ToString()));
        
              Console.WriteLine(s);
              Console.ReadLine();
        
            }
          }
    
        }
