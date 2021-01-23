    private void ListClientButton_Click(object sender, EventArgs e)
    {
        ListClientsBox.Columns.Add("Full name");
        CDB.ListClients(ListClientsBox.Items);
    }
