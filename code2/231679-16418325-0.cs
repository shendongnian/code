            var cellInfos = dataGrid1.SelectedCells;
            foreach (DataGridCellInfo cellInfo in cellInfos)
            {
                if (cellInfo.IsValid)
                {
                    // element will be your DataGridCell Content
                    var element = cellInfo.Column.GetCellContent(cellInfo.Item); 
                    if (element != null)
                    {
                        var myCell = element.Parent as DataGridCell;
                    }
                }
            }
