    private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string imagename = cmbDataGridLink.SelectedItem.ToString();
        int selectedRow = dataGridView1.CurrentCell.RowIndex;
        string filepath = dataGridView1.Rows[selectedRow].Cells[2].Value.ToString();
        string path = filepath + imagename;
        picbComboBox.Image = Image.FromFile(path);
    }
