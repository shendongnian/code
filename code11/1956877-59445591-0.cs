    // Loop through the matrix
    for (int i = cells.GetLowerBound(0); i <= cells.GetUpperBound(0); i++) {
        for ( int j = cells.GetLowerBound(1); j <= cells.GetUpperBound(1); j++)  {
            // Get an element
            var element = cells[i, j];
            // Set an element
            int[]indices = new int[] { i, j };
            cells.SetValue(value, indices);
        }
    }
