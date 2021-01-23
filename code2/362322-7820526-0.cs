        dt = new DataTable();          
        dt_Property.Columns.Add("Field1");
        int i = 0;
        DataRow row = null;
        foreach (DataRow r in ds.Tables[0].Rows)
        {               
                row = dt.NewRow();                    
                row["Field1"] = ds.Tables[0].Rows[i][1];
                dt_Property.Rows.Add(row);   
                i = i + 1;
        }
        dataGridView1.DataSource = dt;
