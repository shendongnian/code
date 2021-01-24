    Datatable dt;    // that is the source datatable
    DataView SortedDataView = new DataView();
    SortedDataView = dt.DefaultView;
    SortedDataView.Sort = "COlumnNameToSortBy DESC";
    dt = SortedDataView.ToTable();
