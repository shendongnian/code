    private void AdjustColumnOrder()
    {
        customersDataGridView.Columns["CustomerID"].Visible = false;
        customersDataGridView.Columns["ContactName"].DisplayIndex = 0;
        customersDataGridView.Columns["ContactTitle"].DisplayIndex = 1;
        customersDataGridView.Columns["City"].DisplayIndex = 2;
        customersDataGridView.Columns["Country"].DisplayIndex = 3;
        customersDataGridView.Columns["CompanyName"].DisplayIndex = 4;
    }
