            EntityCollection result = serviceProxy.RetrieveMultiple(querybyattribute);
            DataTable dt = new DataTable();
            dt.Columns.Add("Title");
            dt.Columns.Add("Created On", typeof(DateTime));
            foreach (Entity entity in result.Entities)
            {
                DataRow dr = dt.NewRow();
                dr["Title"] = entity.Attributes["title"].ToString();
                dr["Created On"] = entity.Attributes["createdon"];
                dt.Rows.Add(dr);
            }
            DataView dv = dt.DefaultView;
            dv.Sort = "Created On desc";
            DataTable sortedDT = dv.ToTable();
            dataGridView1.DataSource = sortedDT;
