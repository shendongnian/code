               if (dt == null)
                {
                    DataTable table = new DataTable();
                    dataGridView2.DataSource = table ;
                    MessageBox.Show("There's no result with " + textBox2.Text);
                }
               
