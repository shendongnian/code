    try
            {
                ((DataTable)dataGridViewX1.DataSource).DefaultView.RowFilter = "Column_Name like'" + textBox1.Text.Trim().Replace("'", "''") + "%'";
            }
            catch (Exception)
            {
                
            }
