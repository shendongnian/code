    List<DataGridColumn> GetColumnInfo(DataGrid dg) {
        List<DataGridColumn> columnInfos = new List<DataGridColumn>();
        foreach (var column in dg.Columns) {
            columnInfos.Add(column);
        }
        return columnInfos;
    }
    List<SortDescription> GetSortInfo(DataGrid dg) {
        List<SortDescription> sortInfos = new List<SortDescription>();
        foreach (var sortDescription in dg.Items.SortDescriptions) {
            sortInfos.Add(sortDescription);
        }
        return sortInfos;
    }
    void SetColumnInfo(DataGrid dg, List<DataGridColumn> columnInfos) {
        columnInfos.Sort((c1, c2) => { return c1.DisplayIndex - c2.DisplayIndex; });
        foreach (var columnInfo in columnInfos) {
            var column = dg.Columns.FirstOrDefault(col => col.Header == columnInfo.Header);
            if (column != null) {
                column.SortDirection = columnInfo.SortDirection;
                column.DisplayIndex = columnInfo.DisplayIndex;
                column.Visibility = columnInfo.Visibility;
            }
        }
    }
    void SetSortInfo(DataGrid dg, List<SortDescription> sortInfos) {
        dg.Items.SortDescriptions.Clear();
        foreach (var sortInfo in sortInfos) {
            dg.Items.SortDescriptions.Add(sortInfo);
        }
    }
