        public static DataGridRow GetSelectedRowFromGrid(this DataGrid myDataGrid)
        {
            return (DataGridRow)
               myDataGrid.ItemContainerGenerator.ContainerFromItem(myDataGrid.SelectedItem);
        }
