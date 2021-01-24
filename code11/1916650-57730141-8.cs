    void HexagonFall(GameObject[,] hexArray)
    {
        // Handle fall for base columns and for offset columns
        for (int offset = 0 ; offset < 2 ; offset++)
        {
            // Handle fall for each column at current offset
            for (int x = 0 ; x < hexArray.GetLength(0) - offset ; x++)
            {
                int bottomYIndex = hexArray.GetLength(1) - offset - 1;
                // List of indices of where each hexagon in that column will come from.
                // We will fill from bottom to top.
                List<Vector2Int> sourceIndices = new List<Vector2Int>();
                for (int y = bottomYIndex ; y >= 0 ; y-=2)
                {
                    // HexExists returns true if the hex isn't empty. 
                    // Something along the lines of ` return input!=null; `
                    // depending on what "empty" hexes look like in the array
                    if (HexExists(hexArray[x,y]))
                    {
                        sourceIndices.Add(new Vector2Int(x,y));
                    }
                }
                // We have a list of where to get each bottom hexes from, now do the move/create
                for (int y = bottomYIndex; y >= 0 ; y-=2)
                {
                    if (sourceIndices.Count > 0)
                    {
                        // If we have any available hexes in column,
                        // use the bottommost one (at index 0)
                        hexArray[x,y] = hexArray[sourceIndices[0].x, sourceIndices[0].y];
                        // We have now found a home for hex previously at sourceIndices[0].
                        // Remove that index from list so hex will stay put.
                        sourceIndices.RemoveAt(0);
                    }
                    else 
                    {
                        // Otherwise, we need to generate a new hex
                        hexArray[x,y] = MakeNewHexAt(new Vector2Int(x,y));
                    }
                    hexArray[x,y].transform.name = "X: " + x + " | Y: " + y;
                }            
            }
        }
    }
