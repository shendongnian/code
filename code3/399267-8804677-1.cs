    protected void Page_Init(object source, System.EventArgs e)
    {
        DefineGridStructure();
    }
    private void DefineGridStructure()
    {
        RadGrid1.ID = "RadGrid1";
        RadGrid1.DataSourceID = "SqlDataSource1";
        RadGrid1.AutoGenerateColumns = false;
        RadGrid1.MasterTableView.DataKeyNames = new string[] { "CustomerID" };
        RadGrid1.Width = Unit.Percentage(98);
        RadGrid1.PageSize = 3;
        RadGrid1.AllowPaging = true;
        RadGrid1.AllowSorting = true;
        RadGrid1.PagerStyle.Mode = GridPagerMode.NextPrevAndNumeric;
        RadGrid1.AutoGenerateColumns = false;
        RadGrid1.ShowStatusBar = true;
        RadGrid1.MasterTableView.PageSize = 3;
        //Add columns
        GridBoundColumn boundColumn;
        boundColumn = new GridBoundColumn();
        boundColumn.DataField = "CustomerID";
        boundColumn.HeaderText = "CustomerID";
        RadGrid1.MasterTableView.Columns.Add(boundColumn);
        boundColumn = new GridBoundColumn();
        boundColumn.DataField = "ContactName";
        boundColumn.UniqueName = "ContactName";
        boundColumn.HeaderText = "Contact Name";
        RadGrid1.MasterTableView.Columns.Add(boundColumn);
        //Detail table - Orders (II in hierarchy level)
        GridTableView tableViewOrders = new GridTableView(RadGrid1);
        tableViewOrders.Name = "Child1";
        tableViewOrders.DataSourceID = "SqlDataSource2";
        tableViewOrders.Width = Unit.Percentage(100);
        tableViewOrders.DataKeyNames = new string[] { "OrderID" };
        GridRelationFields relationFields = new GridRelationFields();
        relationFields.MasterKeyField = "CustomerID";
        relationFields.DetailKeyField = "CustomerID";
        tableViewOrders.ParentTableRelation.Add(relationFields);
        RadGrid1.MasterTableView.DetailTables.Add(tableViewOrders);
        //Add columns
        boundColumn = new GridBoundColumn();
        boundColumn.DataField = "OrderID";
        boundColumn.HeaderText = "OrderID";
        tableViewOrders.Columns.Add(boundColumn);
        boundColumn = new GridBoundColumn();
        boundColumn.DataField = "OrderDate";
        boundColumn.UniqueName = "OrderDate";
        boundColumn.HeaderText = "Date Ordered";
        tableViewOrders.Columns.Add(boundColumn);
        //Detail table Order-Details (III in hierarchy level)
        GridTableView tableViewOrderDetails = new GridTableView(RadGrid1);
        tableViewOrderDetails.Name = "Child2";
        tableViewOrderDetails.DataSourceID = "SqlDataSource3";
        tableViewOrderDetails.Width = Unit.Percentage(100);
        tableViewOrderDetails.DataKeyNames = new string[] { "OrderID" };
        GridRelationFields relationFields2 = new GridRelationFields();
        relationFields2.MasterKeyField = "OrderID";
        relationFields2.DetailKeyField = "OrderID";
        tableViewOrderDetails.ParentTableRelation.Add(relationFields2);
        tableViewOrders.DetailTables.Add(tableViewOrderDetails);
        boundColumn = new GridBoundColumn();
        boundColumn.DataField = "UnitPrice";
        boundColumn.HeaderText = "Unit Price";
        tableViewOrderDetails.Columns.Add(boundColumn);
        boundColumn = new GridBoundColumn();
        boundColumn.DataField = "Quantity";
        boundColumn.HeaderText = "Quantity";
        boundColumn.UniqueName = "Quantity";
        tableViewOrderDetails.Columns.Add(boundColumn);
        //Add the RadGrid instance to the controls
        RadGrid1.PreRender += new EventHandler(RadGrid1_PreRender);
        RadGrid1.DetailTableDataBind += new GridDetailTableDataBindEventHandler(RadGrid1_DetailTableDataBind);
    }
    void RadGrid1_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
    {
        if (e.DetailTableView.Name == "Child1")
        {
            foreach (GridColumn column in e.DetailTableView.Columns)
            {
                if (column.UniqueName == "OrderDate")
                {
                    column.Visible = false;
                }
            }
        }
        if (e.DetailTableView.Name == "Child2")
        {
            foreach (GridColumn column in e.DetailTableView.Columns)
            {
                if (column.UniqueName == "Quantity")
                {
                    column.Visible = false;
                }
            }
        }
    }
    void RadGrid1_PreRender(object sender, EventArgs e)
    {
        
    }
