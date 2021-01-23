    // Associate your BSs with your DGVs.
    ParentDataGridView.DataSource = parentBindingSource;
    ChildDataGridView.DataSource = childBindingSource;
    
    // (Most of) your code here:
    DataSet dSet = new DataSet();
    DataTable ParentList = ListToDataTable(_listOfAllAlbumObjects);
    DataTable ChildList = ListToDataTable(_listOfAllTrackObjects);
    dSet.Tables.AddRange(new DataTable[]{ParentList, ChildList});
    DataColumn parentRelationColumn = ParentList.Columns["AlbumId"];
    DataColumn childRelationColumn = ChildList.Columns["AlbumId"];
    dSet.Relations.Add("ParentToChild", parentRelationColumn, childRelationColumn);
    
    // Let's name this DT to make clear what we're referencing later on.
    ParentList.TableName = "ParentListDT";
    
    // Rather than set the data properties on your DGVs, set them in your BindingSources.
    parentBindingSource.DataSource = dSet;
    parentBindingSource.DataMember = "ParentListDT";
    
    childBindingSource.DataSource = parentBindingSource;
    childBindingSource.DataMember = "ParentToChild";
