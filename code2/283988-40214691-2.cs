    // Prevent exception when hiding rows out of view
    CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView3.DataSource];
    currencyManager.SuspendBinding();
    // Show all lines
    for (int u = 0; u < dataGridView3.RowCount; u++)
    {
        dataGridView3.Rows[u].Visible = true;
        x++;
    }
    // Hide the ones that you want with the filter you want.
    for (int u = 0; u < dataGridView3.RowCount; u++)
    {
        if (dataGridView3.Rows[u].Cells[4].Value == "The filter string")
        {
            dataGridView3.Rows[u].Visible = true;
        }
        else
        {
            dataGridView3.Rows[u].Visible = false;
        }
    }
    // Resume data grid view binding
    currencyManager.ResumeBinding();
