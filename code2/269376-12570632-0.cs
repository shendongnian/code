       public static void Main(string[] args)
        {
            DataTable act = new DataTable();
            act.Columns.Add(new DataColumn("id", typeof(System.Int32)));
            act.Columns.Add(new DataColumn("name"));
            act.Columns.Add(new DataColumn("email"));
            act.Columns.Add(new DataColumn("phone"));
            DataRow dr = act.NewRow();
            dr["id"] = 101;
            dr["name"] = "Rama";
            dr["email"] = "rama@mail.com";
            dr["phone"] = "0000000001";
            act.Rows.Add(dr);
            dr = act.NewRow();
            dr["id"] = 102;
            dr["name"] = "Talla";
            dr["email"] = "talla@mail.com";
            dr["phone"] = "0000000002";
            act.Rows.Add(dr);
            dr = act.NewRow();
            dr["id"] = 103;
            dr["name"] = "Robert";
            dr["email"] = "robert@mail.com";
            dr["phone"] = "0000000003";
            act.Rows.Add(dr);
            dr = act.NewRow();
            dr["id"] = 104;
            dr["name"] = "Kevin";
            dr["email"] = "kevin@mail.com";
            dr["phone"] = "0000000004";
            act.Rows.Add(dr);
            dr = act.NewRow();
            dr["id"] = 106;
            dr["name"] = "TomChen";
            dr["email"] = "tomchen@mail.com";
            dr["phone"] = "0000000005";
            act.Rows.Add(dr);
           var lselColumns = new[] {"id", "name"};
           var dt = act.DefaultView.ToTable(true, lselColumns);
           foreach (DataRow drow in dt.Rows)
           {
               string drowData = string.Empty;
               foreach (DataColumn r in drow.Table.Columns)
               {
                   drowData += (drowData == string.Empty) ? drow[r] : "|" + drow[r];
               }
               Console.WriteLine(drowData);
           }
           Console.ReadLine();
        }
