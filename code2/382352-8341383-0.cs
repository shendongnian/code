    foreach (var item in Tile.Within)
    {
        if (item is Bee)
        {
            ((Bee)item).Selected = !((Bee)item).Selected;
        }
    }
