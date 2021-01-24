    public void CreateNewViewGrid(Grid grid)
            {
                var pattern = grid.Patterns.Grid;
                var rowCount = pattern.Pattern.RowCount;
                var colCount = pattern.Pattern.ColumnCount;
                var values = new List<object>();
    
                List<string> columnNames = new List<string>();
                columnNames.Add("Vessel Id");
                columnNames.Add("Voyage Id");
                columnNames.Add("Load Date");
                columnNames.Add("Dis Date");
                columnNames.Add("Vessel Name");
                columnNames.Add("Status");
    
                for (int i = 0; i < rowCount; i++)
                {
    
                    var item = pattern.Pattern.GetItem(i, 0);
                    var item2 = pattern.Pattern.GetItem(i, 1);
                    var value = (item2.Patterns.Value.Pattern.Value).ToString();
                    values.Add((value));
    
                    foreach (var data in columnNames)
                    {
                        if (value == data)
                        {
    
                            var itemStatus = item.AsGridCell();
    
                            itemStatus.Click();
    
                        }
                    }
    
                }
    
                //Console.WriteLine(string.Join(", ", values));
                //return values;
            }
