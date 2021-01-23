    try
            {
                ((DataTable)dataGridViewX1.DataSource).DefaultView.RowFilter = "Team_Name like'" + textBoxX1.Text.Trim().Replace("'", "''") + "%'";
            }
            catch (Exception)
            {
                
            }
