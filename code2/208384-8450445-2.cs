        PropertyDescriptor pd = DependencyPropertyDescriptor
                                 .FromProperty(DataGridColumn.ActualWidthProperty,
                                               typeof(DataGridColumn));
            foreach (DataGridColumn column in Columns) {
                    //Add a listener for this column's width
                    pd.AddValueChanged(column, 
                                       new EventHandler(ColumnWidthPropertyChanged));
            }
