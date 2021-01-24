    void HexagonFall(Vector2Int missingHexCoord, Hexagon[,] hexArray)
    {
        while (missingHexCoord.y > 1)
        {
            hexArray[missingHexCoord.x,missingHexCoord.y] =   
                    hexArray[missingHexCoord.x, missingHexCoord.y-2];
            missingHexCoord.y -= 2;
        }
    
        hexArray[missingHexCoord.x, missingHexCoord.y] = GenerateNewHex();
    }
