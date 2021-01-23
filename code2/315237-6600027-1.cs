            public void BindData()
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("productName", typeof(string));
                dt.Columns.Add("unitCost", typeof(decimal));
    
                dt.Rows.Add(1, "Pineapple", 1.45);
                dt.Rows.Add(3, "Apple", 1.45);
                dt.Rows.Add(17, "Orange", 6.33);
                dt.Rows.Add(23, "Pear", 17.32);
                dt.Rows.Add(27, "Banana", 12.20);
    
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
    
            protected void btnSubmit_Click(object sender, EventArgs e)
            {
                BindData();
            }
