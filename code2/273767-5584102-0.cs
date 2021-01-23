    compareResult = ObjectCompare.Compare
        (listviewX.SubItems[ColumnToSort].Text,
         listviewY.SubItems[ColumnToSort].Text);
        
    // Calculate correct return value based on object comparison
    if (OrderOfSort == SortOrder.Ascending)
    {
        // Ascending sort is selected, return normal result of compare operation
        return compareResult;
    }
    else if (OrderOfSort == SortOrder.Descending)
    {
        // Descending sort is selected, return negative result of compare operation
        return (-compareResult);
    }
    else
    {
        // Return '0' to indicate they are equal
        return 0;
    }
