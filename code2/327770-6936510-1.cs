    DataTable dt = new DataTable();
            for (int i = 0; i < 5; i++)
            {
                dt.Columns.Add("Col " + i);
            }
            for (int i = 0; i < 10; i++)
            {
                DataRow r = dt.NewRow();
                r.ItemArray=new object[]{"row "+i,"row "+i,"row "+i,"row "+i,"row "+i};
                dt.Rows.Add(r);
            }
            grid.DataSource = dt;
            grid.DataBind();
