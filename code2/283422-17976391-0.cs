        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Get the selected row from user
            DataGridViewRow SelectedRow = dataGridView1.Rows[e.RowIndex];
            //Get the value at the cells in the Row
            string Username = SelectedRow.Cells["Username"].Value.ToString();
            string Password = SelectedRow.Cells["Password"].Value.ToString();
            //Set the value to the text box
            txtUsername.Text = Username;
        }
