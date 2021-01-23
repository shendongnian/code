    private void ResultsDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyType == typeof(DateTime))
        {
            DataGridTextColumn dataGridTextColumn = e.Column as DataGridTextColumn;
            if (dataGridTextColumn != null)
            {
                dataGridTextColumn.Binding.StringFormat = "{0:d}";
            }
        }
    }
