    private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get ID 
            int id = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value);
            // Find Object
            var obj = PictureAPI.GET().First(A => A.ID == id);
        }
