            string [] displayedColumnOrder;
        private void dataGrid_ColumnDisplayIndexChanged( object sender , DataGridColumnEventArgs e )
        {
            DataGrid _dataGrid = ( DataGrid ) sender;
            _getColumnOrder( _dataGrid.Columns );        
        }
        private void dataGrid_Loaded( object sender , RoutedEventArgs e )
        {
            DataGrid _datagrid = ( DataGrid ) sender;  
            _getColumnOrder( _datagrid.Columns );
        }
        void _getColumnOrder( IEnumerable<DataGridColumn> columnCollection )
        {
            DataGridColumn [] columnArray;
            int columnIndexWorking;
            displayedColumnOrder = new string [columnCollection.Count() ];
            columnArray = columnCollection.ToArray();
            foreach( var item_Column in columnCollection )
            {
                columnIndexWorking = item_Column.DisplayIndex;
                displayedColumnOrder [ columnIndexWorking ] = item_Column.Header.ToString();         
            }                                                                                        
        }
