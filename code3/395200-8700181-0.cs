    foreach (DataColumn column in dt.Columns)
            {
                BoundField nameColumn = new BoundField();
                nameColumn.DataField = column.ColumnName.ToString();
                nameColumn.SortExpression = column.ColumnName.ToString();
                nameColumn.HeaderText = column.ColumnName.ToString();
                
                gridView.Columns.Add(nameColumn);
            }
