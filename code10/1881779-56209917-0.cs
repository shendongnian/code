    IList<int[]> indices = new List<int[]>();
    foreach (var child in Maindispgrid.Children)
    {
        int rowIndex = Grid.GetRow(child);
        int columnIndex = Grid.GetColumn(child);
        indices.Add(new int[] {rowIndex, columnIndex});
    }
    // work with the "indices" list
