    void BindDataGrid()
    {
        var gridData = from cm in MyCollection
                       select new 
                       {
                           UniqueId = cm.UniqueId,
                           Min = cm.SomeNumber ?? 0,
                           Max = cm.SomeOtherNumber ?? 0,
                           Description = cm.Description
                       };
        this.myGrid.DataSource = gridData;
        this.myGrid.DataBind();
    }
