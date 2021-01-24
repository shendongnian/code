    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("CustomerNum", typeof(int));
                dt.Columns.Add("CustomerName", typeof(string));
                dt.Columns.Add("FruitName", typeof(string));
                dt.Columns.Add("Charge", typeof(decimal));
                dt.Rows.Add(new object[] {1,1026, "Bob", "Banana", 3.00}); 
                dt.Rows.Add(new object[] {2,1032, "Jill", "Apple", 2.00}); 
                dt.Rows.Add(new object[] {3,1026, "Bob", "Apple", 3.00}); 
                dt.Rows.Add(new object[] {4,1144, "Marvin", "Banana", 1.00}); 
                dt.Rows.Add(new object[] {5,1753, "Sam", "Pear", 4.00}); 
                dt.Rows.Add(new object[] {6,1026, "Bob", "Banana", 3.00});
                string[] fruits = dt.AsEnumerable().Select(x => x.Field<string>("FruitName")).Distinct().OrderBy(x => x).ToArray();
                DataTable pivot = new DataTable();
                pivot.Columns.Add("CustomerNum", typeof(int));
                pivot.Columns.Add("CustomerName", typeof(string));
                foreach (string fruit in fruits)
                {
                    pivot.Columns.Add(fruit, typeof(decimal));
                }
                var groups = dt.AsEnumerable().GroupBy(x => x.Field<int>("CustomerNum"));
                foreach (var group in groups)
                {
                    DataRow newRow = pivot.Rows.Add();
                    
                    newRow["CustomerNum"] =  group.Key;
                    newRow["CustomerName"] = group.First().Field<string>("CustomerName");
                    foreach (DataRow row in group)
                    {
                        string fruitName = row.Field<string>("FruitName");
                        decimal oldvalue = (newRow[fruitName] == DBNull.Value) ? 0 : (decimal)newRow[fruitName];
                        newRow[fruitName] = oldvalue + row.Field<decimal>("Charge");
                    }
                }
            }
        }
    }
