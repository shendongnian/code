    protected void LinqDataSource_Updating(object sender, LinqDataSourceUpdateEventArgs e)
    {
       // originalObject contains the unchanged object
       var originalObject = (DupeVoucherViewModel)e.OriginalObject;
       // newObject contains the changed object
       var newObject = (DupeVoucherViewModel)e.NewObject;
       // Perform your save using newObject
       yourDataAccessComponent.SaveSomething(newObject);
    }
