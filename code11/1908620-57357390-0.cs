    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication124
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Date", typeof(DateTime));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Volume", typeof(int));
                dt.Rows.Add(new object[] {1, DateTime.Parse("08/01/2019"), "Item", 2});
                dt.Rows.Add(new object[] {1, DateTime.Parse("08/02/2019"), "Item", 3 });
                dt.Rows.Add(new object[] {1, DateTime.Parse("08/03/2019"), "Item", 5 });
                dt = dt.AsEnumerable().OrderBy(x => x.Field<DateTime>("Date")).CopyToDataTable();
                int order = 7;
                foreach(DataRow row in dt.AsEnumerable().Where(x => x.Field<int>("Id") == 1))
                {
                    int oldVolume = row.Field<int>("Volume");
                    if (oldVolume >= order)
                    {
                        row["Volume"] =  row.Field<int>("Volume") - order;
                        break;
                    }
                    else
                    {
                        order -= oldVolume;
                        row["Volume"] = 0;
                    }
                }
     
            }
        }
    }
