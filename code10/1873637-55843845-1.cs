                List<Item> items = new List<Item>();
                items = CreateData(items); // fill with dummy items
                List<Filter> filters = new List<Filter>();
                filters = CreateFilter(filters); // fill with dummy items
                string[,] target = new string[items.Count,filters.Count];
    
                int row = 0, col = 0;
                foreach (var item in items)
                {
                    foreach (var filter in filters)
                    {
                        target[row, col] = GetPropertyValue(item, filter.PropertyName);
                        row++;
                    }
                    row = 0;
                    col++;
    
                }
