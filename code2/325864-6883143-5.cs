    static void rotateLayerX(IEnumerable<Tile> layer)
    {
        foreach (var tile in layer)
        {
            var x = tile.Position.X;
            var y = tile.Position.Y;
            var z = tile.Position.Z;
            tile.Position = new Point3D(x, -z, y);
        }
    }
