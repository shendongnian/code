                   DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                    combo.Name = "......";
                    combo.DataPropertyName = ".....";
                    DataTable dt = obj.SqlDataTable("your sql query")
                                                   
                 
                    foreach (DataRow row in dt.Rows)
                    {
                        combo.Items.Add(row["...."].ToString());
                    }
                       dataGridView1.Columns.Add(combo);
