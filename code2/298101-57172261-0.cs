    //Populate the datagridview
    DataTable _DT = new DataTable();
    BindingSource _BS = new BindingSource();
    //Initially fill up your datatable with stuff
    //You can call this method again if data needed to be changed
    public void fillDT(int id) {
        _DT = fillUpDataTableWithStuffFromDB(id);
        _BS.DataSource = _DT.DefaultView;
        datagridview1.DataSource = _BS;
        _BS.ResetBindings(false);
    }
    //You can use this method to mimic the functionality above
    //But rather fetching data, just clear out the datatable and pass it in
    public void clearDT() {
        _DT.Clear();
        datagridview1.DataSource = _DT.DefaultView;
        datagridview1.Refresh();
    }
