    public static int recursiveCheck(int[,] grid, int x, int y, int finalX, int finalY)
    {
        if(x < 0 || x > finalX || y < 0 || y > finalY)
        {
            return 0;
        }
        var originalValue = grid[x, y];
        if (originalValue == 1)
        {
            return 0;
        }
        if (originalValue == 6)
        {
            return 1;
        }
        grid[x, y] = 1; // prevent deeper recursion from coming back to this space
        var paths = recursiveCheck(grid, x + 1, y, finalX, finalY)
            + recursiveCheck(grid, x, y + 1, finalX, finalY)
            + recursiveCheck(grid, x - 1, y, finalX, finalY)
            + recursiveCheck(grid, x, y - 1, finalX, finalY);
    
        grid[x, y] = originalValue; // allow other path checking to revisit this space.
    
        return paths;
    }
