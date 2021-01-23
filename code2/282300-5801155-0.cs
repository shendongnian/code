    private void button_Click(object sender, EventArgs e)
    {
        StringBuilder message = new StringBuilder();
        foreach (DataGridViewCell cell in this.dataGridView.SelectedCells)
        {
            message.AppendLine("Value = " + cell.Value);
        }
        MessageBox.Show(message.ToString());
    }
