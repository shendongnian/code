        Vector2[] _chassisConcaveVertices =
        {
            new Vector2(5.122f, 0.572f),
            new Vector2(3.518f, 0.572f),
            new Vector2(3.458f, 0.169f),
            new Vector2(2.553f, 0.169f),
            new Vector2(2.013f, 0.414f),
            new Vector2(0.992f, 0.769f),
            new Vector2(0.992f, 1.363f),
            new Vector2(5.122f, 1.363f),
        };
        // find center
        float sumX = 0;
        float sumY = 0;
        foreach (var vector in _chassisConcaveVertices)
        {
            sumX += vector.X;
            sumY += vector.Y;
        }
        Vector2 center = new Vector2(
            sumX / _chassisConcaveVertices.Length, 
            sumY / _chassisConcaveVertices.Length);
        // create a new version of the polygon flipped
        Vector2[] flipped = _chassisConcaveVertices
            .Select(v => new Vector2(
                v.X + (center.X - v.X) * 2, 
                v.Y + (center.Y - v.Y) * 2))
            .ToArray();
