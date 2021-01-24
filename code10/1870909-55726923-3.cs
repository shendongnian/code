    public static void Draw(Shapes s, Color c)
    {
        if (Mapper.TryGetValue(s, out Func<IDrawingObject> drawingObjectFactory))
        {
            IDrawingObject drawingObject = drawingObjectFactory();
            drawingObject.Draw(c);
        }
    }
