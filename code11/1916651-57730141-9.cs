    List<Vector2Int> HexToBeDestroyed = new List<Vector2Int>();
    // ...
    if (MatchedColors == 2)
    {
        if(!HexToBeDestroyed.Contains(new Vector2Int(x, y))
            HexToBeDestroyed.Add(new Vector2Int(x, y));
        if (!HexToBeDestroyed.Contains(new Vector2Int(x - 1, y))
            HexToBeDestroyed.Add(new Vector2Int(x - 1, y));
        if (!HexToBeDestroyed.Contains(new Vector2Int(x - 1, y - 1)))
            HexToBeDestroyed.Add(new Vector2Int(x - 1, y - 1));
    }
    // ...
    foreach (Vector2Int V in HexToBeDestroyed)
    {
        if (Hexagons[V.x,V.y] != null)
        {
            Destroy(Hexagons[V.x,V.y]);
            Hexagons[V.x,V.y] = null;
        }
    }
