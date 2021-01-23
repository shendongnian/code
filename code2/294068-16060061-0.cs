                    OracleCommand cmd = new OracleCommand(commandText, _oraConn);
                    OracleDataReader dr = cmd.ExecuteReader();
                    int i = 0;
                    while (dr.Read())
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dataGridView1);
                        row.Cells[0].Value = dr.GetValue(0).ToString();
                        row.Cells[1].Value = dr.GetValue(1).ToString();
                        row.Cells[2].Value = dr.GetValue(2).ToString();
                        row.Cells[3].Value = dr.GetValue(3).ToString();
                        row.Cells[4].Value = dr.GetValue(4).ToString();
                        row.Cells[5].Value = dr.GetValue(5).ToString();
                        dataGridView1.Rows.Add(row);
                        //MessageBox.Show( dr.GetValue("vz_id").ToString());
                        i++;
                    };
