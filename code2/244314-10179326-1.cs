    var filterExpression = gridOrderLineItems.MasterTableView.FilterExpression;
    if (!string.IsNullOrEmpty(filterExpression))
       allItems = allItems.AsQueryable()
                  .Where(filterExpression)
                  .ToList();
