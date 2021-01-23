    try {
        DateTime dateX = Convert.ToDateTime(listviewX.SubItems[ColumnToSort].Text);
        DateTime dateY = Convert.ToDateTime(listviewY.SubItems[ColumnToSort].Text);
        compareResult = ObjectCompare.Compare(dateX, dateY);
    }
    catch {
        compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
    }
