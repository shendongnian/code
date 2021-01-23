     for (int i = 0; i < dataGridView1.RowCount; i++) {
                        for (int j = 0; j < dataGridView1.ColumnCount; j++) {
                            
                            if (dataGridView1.Rows[i].Cells[j].Value==DBNull.Value)
                            {
                                dataGridView1.Rows[i].Cells[j].Value = "null";
                            }
                        }
                    }
                    dataGridView1.Update();
