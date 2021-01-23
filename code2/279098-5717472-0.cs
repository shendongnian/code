    string s = "Id,Name ,Dept\r\n1,Mike,IT\r\n2,Joe,HR\r\n3,Peter,IT\r\n";
                DataTable dt = new DataTable();
    
                string[] tableData = s.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var col = from cl in tableData[0].Split(",".ToCharArray())
                          select new DataColumn(cl);
                dt.Columns.AddRange(col.ToArray());
                dt.Rows.Add(
                            from st in tableData.Skip(1) select st.Split(",".ToCharArray()));
