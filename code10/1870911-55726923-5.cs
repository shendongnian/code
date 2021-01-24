    public static void Draw(Shapes s, Color c)
    {
        if (Mapper.TryGetValue(s, out IDrawingObject drawingObject))
        {
            drawingObject.Draw(c);
        }
    }
