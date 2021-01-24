    public void aaa(int i)
    {
        DataTable dt = new DataTable(); ///this will initialize every time, a new data table will be created every loop
        dt.Columns.Add("host");
        DataRow dr = dt.NewRow();
        for (int a = 1; a <= i; a++)
        {
            dr[a] = i;
        }
            dt.Rows.Add(dr);
        this.dataGridView1.DataSource = dt;
    }
