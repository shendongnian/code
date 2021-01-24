    public List<MapHex> GetNeighborsInRange(MapHex hex, int distance)
    {
        List<MapHex> neighbors = new List<MapHex>();
        if (distance == 0)
        {
            foreach (Vector2 dir in oddQDirections)
            {
                MapHex next = allMapHexes.Find(item => item.coordinate == new Vector2(hex.coordinate.x + dir.x, hex.coordinate.y + dir.y));
                if (next != null)
                {
                    neighbors.Add(next);
                }
            }
        }
        else
        {
            foreach (MapHex closeHex in nonEmptyMapHexes)
            {
                if (HexHeuristicDistance(hex, closeHex) <= distance)
                {
                    neighbors.Add(closeHex);
                }
            }
        }
        return neighbors;
    }
