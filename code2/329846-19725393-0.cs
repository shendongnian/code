        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //this code is used to search Name on the basis of TextBox1.text
                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("Column_Name like '%{0}%'", TextBox1.Text.Trim().Replace("'", "''"));
            }
            catch (Exception) 
            {
            }
        }
