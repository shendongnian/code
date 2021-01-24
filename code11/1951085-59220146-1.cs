    private void DrawGrid(DataTable table)
        {
            foreach (var column in table.Columns)
            {
                grdMain.ColumnDefinitions.Add(new ColumnDefinition());
            }
            int rowNumber = 0;
            foreach (DataRow row in table.Rows)
            {
                grdMain.RowDefinitions.Add(new RowDefinition());
                for (int columnNumber = 0; columnNumber < table.Columns.Count; columnNumber++)
                {
                    var cellText = new TextBlock()
                    {
                        Text = row[columnNumber].ToString(),
                    };
                    grdMain.Children.Add(cellText);
                    cellText.SetValue(Grid.RowProperty, rowNumber);
                    cellText.SetValue(Grid.ColumnProperty, columnNumber);
                }
                rowNumber++;
            }
            for (int colNumber = 0; colNumber < grdMain.ColumnDefinitions.Count; colNumber++)
            {
                var rect = GetColumnRectangle(colNumber, rowNumber);
                grdMain.Children.Add(rect);
                //Dictionary; indicating whether the column is selected
                _rectangles.Add(rect, false);
            }
        }
