    foreach(var column in gridItem.ColumnDefinitions)
    {
        var name = column.GetValue(FrameworkElement.NameProperty) as string;
        if (name == "IsCheckedColumn")
            column.Width = show ? CheckUncheckColumn_VisibleWidth : Column_InvisibleWidth;
        else if (name == "DeleteColumn")
            column.Width = show ? DeleteColumn_VisibleWidth : Column_InvisibleWidth;
    }
