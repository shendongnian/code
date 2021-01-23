     public void generateListView(ObjectListView varListView, List<ColumnNameSize> nameSizeList) {
    
            List<OLVColumn>  columnsList = new List<OLVColumn>();
            foreach (ColumnNameSize nameSize in nameSizeList) {
                OLVColumn columnHeader = new BrightIdeasSoftware.OLVColumn();  
                columnHeader.Width = nameSize.ColumnSize;
                columnHeader.Text = nameSize.ColumnName;
                columnsList .Add(columnHeader);
                varListView.AllColumns.Add(columnHeader);
            }
            varListView.Columns.AddRange( columnsList.Cast<System.Windows.Forms.ColumnHeader>().ToArray());
        }
