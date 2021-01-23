    protected void RadGrid1_Init(object sender, EventArgs e)
    {
        DefineGridStructure();
    }
    private void DefineGridStructure()
    {
        RadGrid1.MasterTableView.DataKeyNames = new string[] { "EmpId" };
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
        boundColumn.DataField = "EmpId";
        boundColumn.HeaderText = "EmpId";
        RadGrid1.MasterTableView.Columns.Add(boundColumn);
        boundColumn = new GridBoundColumn();
        boundColumn.DataField = "Name";
        boundColumn.HeaderText = "Name";
        RadGrid1.MasterTableView.Columns.Add(boundColumn);
        boundColumn = new GridBoundColumn();
        boundColumn.DataField = "Age";
        boundColumn.HeaderText = "Age";
        RadGrid1.MasterTableView.Columns.Add(boundColumn);
        //Detail table - Orders (II in hierarchy level)
        GridTableView tableViewOrders = new GridTableView(RadGrid1);
        tableViewOrders.Width = Unit.Percentage(100);
        tableViewOrders.DataKeyNames = new string[] { "EmpId" };
        GridRelationFields relationFields = new GridRelationFields();
        relationFields.MasterKeyField = "EmpId";
        relationFields.DetailKeyField = "EmpId";
        tableViewOrders.ParentTableRelation.Add(relationFields);
        RadGrid1.MasterTableView.DetailTables.Add(tableViewOrders);
        //Add columns
        boundColumn = new GridBoundColumn();
        boundColumn.DataField = "Street";
        boundColumn.HeaderText = "Street";
        tableViewOrders.Columns.Add(boundColumn);
        boundColumn = new GridBoundColumn();
        boundColumn.DataField = "City";
        boundColumn.HeaderText = "City";
        tableViewOrders.Columns.Add(boundColumn);
        boundColumn = new GridBoundColumn();
        boundColumn.DataField = "Zip";
        boundColumn.HeaderText = "Zip";
        tableViewOrders.Columns.Add(boundColumn);
    }
