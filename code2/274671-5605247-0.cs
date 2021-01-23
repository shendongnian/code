    private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.RowIndex != 0 && dataGridView.SelectedRows.Count>0)
        {
            int studentID = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
            StudentInformation addForm = new StudentInformation(studentID);
            addForm.ShowDialog();
        }            
    }
