    for (int j = 0; j < 5; j++)
        {
            GridView Grid = new GridView();
            ArrayList machID = new ArrayList();
            ArrayList machName = new ArrayList();
            //NEW LINE (doesn't need the comment or the blank space tho)
            Grid.RowDataBound += Grid_RowDataBound;
            Grid.ID = machGrps[j].ToString();
            Grid.AllowSorting = true;
            Grid.CellSpacing = 2;
            Grid.GridLines = GridLines.None;
            Grid.Width = Unit.Percentage(100);
