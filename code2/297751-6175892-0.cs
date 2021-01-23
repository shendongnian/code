    private void dataGridView_SelectionChanged(object sender, EventArgs e)
    {
        // Update the text of TextBox controls.
        textBox1.Text = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
        textBox2.Text = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
        ....
    }
