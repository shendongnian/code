    DateTime dateX;
    DateTime dateY;
    if (
    	DateTime.TryParse(listviewX.SubItems[ColumnToSort].Text, out dateX)
    	&& DateTime.TryParse(listviewY.SubItems[ColumnToSort].Text, out dateY)
    	)
    {
    	compareResult = ObjectCompare.Compare(dateX, dateY);
    }
    else
    {
    	compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
    }
