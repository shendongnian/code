        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn { DataType = typeof(int), ColumnName = "A" });
            dt.Columns.Add(new DataColumn { DataType = typeof(int), ColumnName = "b" });
            dt.Columns.Add(new DataColumn { DataType = typeof(string), ColumnName = "c" });
            DataRow r;
            for (int i=0;i<=5 ;i++)
            {
                r = dt.NewRow();
                r["A"] = i;
                r["b"] = i + 2;
                r["c"] = i.ToString();
                dt.Rows.Add(r);
            }
            var query = from DataRow row in dt.Rows.Cast<DataRow>().ToList()
                        let textUnion = GetFields(row)
                        select new { textUnion };
            dataGridView1.DataSource = query.ToList();
        
        }
        string GetFields(DataRow row)
        {
            StringBuilder retValue=new StringBuilder();
            for (int i = 0; i < row.ItemArray.Length;i++ )
            {
                retValue.Append(Convert.ToString(row[i]));
            }
            return retValue.ToString();
        }
