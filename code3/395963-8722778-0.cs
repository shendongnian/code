                var datasource = from p in (object[])
                                 select new
                                 {
                                     Column1 = p.GetType().GetProperty("property1").GetValue(p, null),
                                     Column2 = p.GetType().GetProperty("property2").GetValue(p, null),
                                     Column3 = p.GetType().GetProperty("property3").GetValue(p, null),
                                     Column4 = p.GetType().GetProperty("property4").GetValue(p, null),
                                 };
    
    
                dataGridView1.DataSource = datasource;
    
                dataGridView1.Columns[0].DataPropertyName = "Column1";
    
                dataGridView1.Columns[1].DataPropertyName = "Column2";
    
                dataGridView1.Columns[2].DataPropertyName = "Column3";
    
                dataGridView1.Columns[3].DataPropertyName = "Column4";
