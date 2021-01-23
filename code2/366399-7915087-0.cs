    private void comboBox1_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            MessageBox.Show(comboBox1.SelectedText);
        }
    }
