    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Item");
            dt.Columns.Add("Access1");
            dt.Columns.Add("Access2");
            dt.Columns.Add("Access3");
            dt.Columns.Add("Access4");
            dt.Columns.Add("Access5");
            dt.TableName = "Permission";
            for (int i = 0; i < 6; i++)
            {
                var row = dt.NewRow();
                row["Item"] = i;
                row["Access1"] = (i % 2 == 0 ? true : false);
                row["Access2"] = (i % 2 == 0 ? true : false);
                row["Access3"] = (i % 3 == 0 ? true : false);
                row["Access4"] = (i % 3 == 0 ? true : false);
                row["Access5"] = (i % 4 == 0 ? true : false);
                dt.Rows.Add(row);
            }
            dt.AcceptChanges();
            DataSet ds = new DataSet("Permissions");
            ds.Tables.Add(dt);
            var output = Console.OpenStandardOutput();
            ds.WriteXml(output);
            
            Console.ReadLine();
        }
    }
