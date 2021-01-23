    private void mChangeReadOnlyButton_Click(object sender, EventArgs e)
    {
       ComboBoxColumn2.DisplayStyle = (dataGridView1.ReadOnly) ?
          DataGridViewComboBoxDisplayStyle.ComboBox :
          DataGridViewComboBoxDisplayStyle.Nothing;
       dataGridView1.ReadOnly = !dataGridView1.ReadOnly;
    }
