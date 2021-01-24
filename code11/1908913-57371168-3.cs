    private void button1_Click(object sender, EventArgs e)
    {
       aaa(254);
    }
    public void aaa(int i) //value of i = 254
    {
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();
            for (var s = 0; s <= i; s++ ) {
                for (int a = 1; a <= i; a++)
                {
                    dr[a] = i;
                }
                    dt.Rows.Add(dr);
                this.dataGridView1.DataSource = dt;
            }
        }
    }
