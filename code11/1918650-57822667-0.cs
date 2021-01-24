    DataTable table = new DataTable();
    table.Columns.Add(new DataColumn("SelectedValue"));
    DataGridComboBoxColumn dgvCmb = new DataGridComboBoxColumn();
    dgvCmb.SelectedItemBinding = new Binding("SelectedValue");
    dgvCmb.ItemsSource = new List<string>
    {
        "Ghanashyam",
        "Jignesh",
        "Ishver",
        "Anand"
    };
    dataGrid.Columns.Add(dgvCmb);
