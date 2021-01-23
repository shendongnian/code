    private void button3_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            List<Table2> lst = new List<Table2>();
           dc.InsertTable2(Convert.ToDecimal(textBox1.Text), textBox2.Text, Convert.ToChar(textBox3.Text));
            dc.SubmitChanges();
            lst = (from x in dc.Table2s select x).ToList();
            dataGridView1.DataSource = lst;
        }
