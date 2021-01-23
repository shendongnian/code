    private string GetShortName(Tile t)
    {
        return Enum.GetName(typeof(Tile), t).Substring(0, 1);
    }
    ...
    Console.WriteLine(GetShortName(Tile.White));
