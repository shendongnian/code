    string firstSelectedCellText = GetCellText(DataGrid.SelectedCells.First());
    
     private string GetCellText(DataGridCellInfo currentcellInfo)
            {
                var currentCell = GetDataGridCell(currentcellInfo);
                if (currentCell == null) return string.Empty;
                int itemIndex = DataGrid.Items.IndexOf(currentcellInfo.Item);
                DataGrid.CurrentCell = new DataGridCellInfo(DataGrid.Items[itemIndex], currentcellInfo.Column);
                if (currentCell.Content is TextBox textBox)
                {
                    return textBox.Text;
                }
                if (currentCell.Content is TextBlock textBlock)
                {
                    return textBlock.Text;
                }
    
                return string.Empty;
            }
      private DataGridCell GetDataGridCell(DataGridCellInfo cellInfo)
            {
                var cellContent = cellInfo.Column.GetCellContent(cellInfo.Item);
                if (cellContent != null)
                    return (DataGridCell)cellContent.Parent;
    
                return null;
            }
