    DataTable dt = new DataTable();
    private void Form4_Load(object sender, EventArgs e)
    {
        dt.Columns.Add("Column1", typeof(DateTime));
        dateTimePicker1.DataBindings.Add("Value", dt, "Column1");
        dateTimePicker1.DataBindings["Value"].Format += 
            (s, a) => a.Value = ((DateTime)a.Value).ToLocalTime();
        dateTimePicker1.DataBindings["Value"].Parse += 
            (s, a) => a.Value = ((DateTime)a.Value).ToUniversalTime();
        dt.Rows.Add(new DateTime(2000, 1, 1, 13, 0, 0));
    }
    private void button1_Click(object sender, EventArgs e)
    {
        MessageBox.Show($"{dt.Rows[0]["Column1"].ToString()}");
    }
