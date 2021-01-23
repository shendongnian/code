    public int[,] generateGrid() // POSSIBLE UPDATE:: WHEN RESETING GRID ROW, REMEMBER PREVIOUS ORDER TO AVOID SAME COMFLICTION TWICE
    {
        Random rand = new Random();
        ArrayList availableColumnNumbers = new ArrayList();
        ArrayList availableRowNumbers = new ArrayList();
        ArrayList availableNumbers = new ArrayList();
        int[,] grid = new int[_gridSize, _gridSize];
        availableColumnNumbers = resetArrayList(); // create a list that holds the numbers 1 - Grid Size
        availableRowNumbers = resetArrayList(); // create a list that holds the numbers 1 - Grid Size
        for (int row = 0; row < _gridSize; row++) // loop through rows
        {
            for (int column = 0; column < _gridSize; column++) // loop through columns
            {
                if (row == 0) // if row to be filled if the first row
                {
                    int position = rand.Next(availableRowNumbers.Count); // Generate a random position
                    grid[row, column] = (int)availableRowNumbers[position]; // place available row numbers
                    availableRowNumbers.RemoveAt(position); // update available row numbers
                }
                else // row to be filled has constraints. Fill in, taking constraints into consideration
                {
                    // update available column number, finds out what values are already in the column, and generates the only available values 
                    availableColumnNumbers = getAvailableColumnNumbers(grid, column);
                    // combine available Rows and Columns to get a list of available numbers for that cell
                    availableNumbers = getSimilarNumbers(availableRowNumbers, availableColumnNumbers);
                    if (availableNumbers.Count != 0) // if there are available numbers to place,
                    {
                        int position = rand.Next(availableNumbers.Count);
                        grid[row, column] = (int)availableNumbers[position]; // place available number
                        availableRowNumbers.Remove((int)availableNumbers[position]); // update available row numbers
                    }
                    else // Confliction: There are no available numbers (restart entire row)
                    {
                        grid = resetRow(grid, row); // reset the entire row where confliction occured
                        column = -1; // start again at begining of column
                        availableRowNumbers = resetArrayList(); // reset Array List
                    }
                }
            }
            availableRowNumbers = resetArrayList();// reset available row array
        }
        return grid;
