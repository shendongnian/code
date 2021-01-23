    int getColumnIndexByHeaderText(GridView gridView, string headerText)
    {
        for (int i = 0; i < gridView.Columns.Count; ++i)
        {
            if (gridView.Columns[i].HeaderText == headerText)
                return i;
        }
        return -1;
    }
