         private string ConvertToString(DataRow dr)
        {
            return Convert.ToString(dr[0]);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("BestSite", typeof(string));
            dt.Columns.Add(dc);
            for (int i = 1; i <= 10; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = i.ToString() + " = stackoverflow";
                dt.Rows.Add(dr);
            }//EndFor
            //var Query = from mycolumn in dt.AsEnumerable()
            //            where mycolumn.Field<string>("BestSite") != string.Empty
            //            select mycolumn;
            DataRow[] myrow = new DataRow[dt.Rows.Count];
            dt.Rows.CopyTo(myrow, 0);
            string[] myString = Array.ConvertAll(myrow, new Converter<DataRow, string>(ConvertToString));
            foreach (string a in myString)
            {
                listBox1.Items.Add(a);
            }
        }
