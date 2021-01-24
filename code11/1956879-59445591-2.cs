    // Loop through the matrix
    for (int i = cells.GetLowerBound(0); i <= cells.GetUpperBound(0); i++) {
        for (int j = cells.GetLowerBound(1); j <= cells.GetUpperBound(1); j++) {
            int[] indices = new int[] { i, j };
            // Get an element
            object element = cells.GetValue(indices);
            // Set an element
            cells.SetValue(value, indices);
        }
    }
