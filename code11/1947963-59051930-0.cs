    cmd.CommandText = "SELECT * FROM table";
    using (var dr = cmd.ExecuteReader())
        {
            while (dr.Read())
                {
                    this.cr.Add(new GridViewConstruct
                        {
                            item1 = dr["item1"].ToString(),
                            item2 = dr["item2"].ToString(),
                            item3 = string.IsNullOrEmpty(dr["item3"].ToString()) ? "" : dr["item3"].ToString(),
                        });
                }
            dr.Close();
        }
    
    dataGridView1.DataSource = cr.ToList();
