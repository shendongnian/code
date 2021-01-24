    public void aaa(int i) //value of i = 254
    {
        DataTable dt = new DataTable();
        DataRow dr = dt.NewRow();
        for (int a = 1; a <= i; a++)
        {
            dr[a] = i;
        }
        dt.Rows.Add(dr);
        this.dataGridView1.DataSource = dt;
    }
}
