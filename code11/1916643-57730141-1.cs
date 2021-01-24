    void HexagonFall(Hexagon[,] hexArray)
    {
        // Handle fall for base columns and for offset columns
        for (int offset = 0 ; offset < 2 ; offset++)
        {
            // Handle fall for each column at current offset
            for (int x = 0 ; x < hexArray.GetLength(0)-offset ; x++)
            {
                int bottomYIndex = hexArray.GetLength(1)-offset-1;
                // List of indices of where each hexagon in that column will come from.
                // We will fill from bottom to top.
                List<Vector2Int> sourceIndices;
                for (int y = bottomYIndex ; y >= 0 ; y--)
                {
                    // HexExists returns true if the hex isn't empty. might be a null check.
                    if (HexExists(hexArray[x,y])
                    {
                        sourceIndices.Add(new Vector2Int(x,y));
                    }
                }
                // We have a list of where to get each bottom hexes from, now do the move/create
                for (int y = bottomYIndex; y >= 0 ; y--)
                {
                    // If we have any already existing hexes, get the next one
                    if (sourceIndices.Count > 0)
                    {
                        hexArray[x,y] = hexArray[sourceIndices[0].x, sourceIndices[0].y];
                        // We have found a home for hex at sourceIndices[0], remove it from list
                        sourceIndices.RemoveAt(0);
                    }
                    // Otherwise, make a new one
                    else 
                    {
                        hexArray[x,y] = MakeNewHexAt(new Vector2Int(x,y));
                    }
                }            
            }
        }
    }
