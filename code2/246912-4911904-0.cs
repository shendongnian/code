    DataTable invDataTable = GetInvDataTable();
    
    EnumerableRowCollection<DataRow> query =
        from inv in invDataTable.AsEnumerable()
        where order.Field<int>("type") == 15
        select inv;
    
    DataView dv = query.AsDataView();
    
    bindingSource1.DataSource = dv;
