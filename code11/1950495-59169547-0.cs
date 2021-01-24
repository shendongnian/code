      private void button1_Click(object sender, EventArgs e)
        {
            DateTime formatter = dateTimePicker1.Value;
            DateTime latter = dateTimePicker2.Value;
            XDocument doc = XDocument.Load("D:\\t.xml");
            var result = (from x in doc.Descendants("Student")
                         where Convert.ToDateTime(x.Element("Date").Value) <= latter && Convert.ToDateTime(x.Element("Date").Value) >= formatter
                         select x).ToList();
            List<string> column = new List<string>();
            foreach (var item in result.Elements())
            {
                column.Add(item.Name.ToString());
            }
            column=column.Distinct().ToList();
            DataTable table = new DataTable();
            foreach (var item in column)
            {
                table.Columns.Add(item);
            }
            foreach (var item in result)
            {
                table.Rows.Add(item.Element("Name").Value, item.Element("Date").Value, item.Element("Age").Value);
            }
            dataGridView1.DataSource = table;
    
    
    
        }
