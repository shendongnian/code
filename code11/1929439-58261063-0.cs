    DataTable dataTable1 = new DataTable();
            DataTable dataTable2 = new DataTable();
            dataTable1.Columns.Add("Column1", typeof(string));
            dataTable1.Columns.Add("Column2", typeof(string));
            dataTable1.Columns.Add("Column3", typeof(string));
            dataTable2.Columns.Add("Column1", typeof(string));
            dataTable2.Columns.Add("Column2", typeof(string));
            dataTable2.Columns.Add("Column3", typeof(string));
            dataTable1.Rows.Add("Aa", "Bb", "Cc");
            dataTable1.Rows.Add("Dd", "Ee", "Ff");
            dataTable2.Rows.Add("Gg", "Hh", "Ii");
            dataTable2.Rows.Add("Jj", "Kk", "Ll");
            Console.WriteLine("Column1  Column2 Column3");
            for (int i = 0; i < dataTable1.Rows.Count; i++)
            {
                Console.Write("\n"+dataTable1.Rows[i]["Column1"].ToString()+","+ dataTable2.Rows[i]["Column1"].ToString());
                Console.Write("\t" + dataTable1.Rows[i]["Column2"].ToString() + "," + dataTable2.Rows[i]["Column2"].ToString());
                Console.Write("\t" + dataTable1.Rows[i]["Column3"].ToString() + "," + dataTable2.Rows[i]["Column3"].ToString());
            }
            Console.ReadKey();
