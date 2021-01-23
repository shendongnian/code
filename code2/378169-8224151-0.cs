    List<int> rowIndex = new List<int>();
    private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
    {
        if (!rowIndex.Contains(e.RowIndex))
        {
              rowIndex.Add(e.RowIndex);
              MessageBox.Show("Are you want to save changes?", "Save Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        }            
    }
