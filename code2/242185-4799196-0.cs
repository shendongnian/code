    if (!Page.IspostBack) {
        TextBox queryBox = new TextBox();
        queryBox.ID = "querybox";
        queryBox.ToolTip = "Enter your query here and press submit";
        Controls.Add(queryBox);
        Button queryButton = new Button();
        queryButton.UseSubmitBehavior = false;
        queryButton.ID = "querybutton";
        Controls.Add(queryButton);
    } else {
        try {
            string query = querybox.Text;
            DataGrid dataGrid = new DataGrid();
            dataGrid.DataSource = Camelot.SharePointConnector.Data.Helper.ExecuteDataTable(query, connectionString);
            dataGrid.DataBind();
            Controls.Add(dataGrid);
        } catch (Exception a) {
            Controls.Add(new LiteralControl(a.Message));
        } // try
    } // if
