private DataTable ConvertToDataTable(DataGrid dataGrid)
        {
            var dt = new DataTable();
            foreach (DataGridColumn dgCol in dataGrid.Columns)
            {
                if (dgCol.Visible)
                {
                    dt.Columns.Add();
                }
            }
            return dt;
        }
