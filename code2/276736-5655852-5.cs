    private void button1_Click(object sender, EventArgs e)
    {
        if (dataGridView1.DataSource == null)
        {
            List<myRow> data = new List<myRow>();
            data.Add(new myRow { id = 1, txt = "test 1" });
            data.Add(new myRow { id = 2, txt = "test 2" });
            data.Add(new myRow { id = 3, txt = "test 3" });
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("additionalData1", typeof(int));
            dt.Columns.Add("additionalData2", typeof(int));
            Random rnd = new Random();
            foreach (var item in data)
            {
                dt.Rows.Add(new object[] { item.id, rnd.Next(), rnd.Next() });
            }
            MyView.addProperty("additionalData1", dt, row => row["additionalData1"], (row, val) => row["additionalData1"] = val, (tab, v) => tab.Rows.OfType<DataRow>().First(x => x["id"].Equals(v.obj.id)), typeof(int));
            MyView.addProperty("additionalData2", dt, row => row["additionalData2"], (row, val) => row["additionalData2"] = val, (tab, v) => tab.Rows.OfType<DataRow>().First(x => x["id"].Equals(v.obj.id)), typeof(int));
    
            dataGridView1.DataSource = new BindingList<MyView>(data.Select(x => new MyView { obj = x }).ToList());
        }
    }
