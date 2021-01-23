    bool[] canDraw;
    /// <summary>
    /// make sure that the given point is within our image boundaries.
    /// BufferSize(Point) contains the dimensions of the image buffer.
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    bool InBounds(Point p)
    {
        return p.X >= 0 && p.X < BufferSize.X && p.Y >= 0 && p.Y < BufferSize.Y;
    }
    
    /// <summary>
    /// make sure that we haven't already drawn this pixel and that it has
    /// valid coordinates
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    bool CanDraw(Point p)
    {
        return InBounds(p) && canDraw[p.Y * BufferSize.X + p.X];
    }
    
    /// <summary>
    /// Heap "stack" to track which pixels we need to visit
    /// </summary>
    Stack<Point> fillStack = new Stack<Point>();
    
    /// <summary>
    /// initialize recursion.
    /// </summary>
    /// <param name="startPosition"></param>
    /// <param name="fillColor"></param>
    void Fill(Point startPosition, Color fillColor)
    {
        canDraw = Enumerable.Repeat(true, BufferSize.X * BufferSize.Y).ToArray();
        var backgroundColor = GetPixel(startPosition);
    
        if (backgroundColor != fillColor)
        {
            fillStack.Push(startPosition);
            RecurseFloodFill(fillColor, backgroundColor);
        }
    
    }
    
    /// <summary>
    /// data-recurse through the image.
    /// </summary>
    /// <param name="fillColor">Color we want to fill with</param>
    /// <param name="backgroundColor">Initial background color to overwrite</param>
    void RecurseFloodFill(Color fillColor, Color backgroundColor)
    {
        while (fillStack.Count > 0 && !IsExiting)
        {
            /*if (fillStack.Count != depth)
                Debug.WriteLine("Depth: {0}", depth = fillStack.Count);
            */
            var position = fillStack.Pop();
            if(!CanDraw(position))
                continue;
    
            var color = GetPixel(position);
            if (color != backgroundColor)
                continue;
    
            SetPixel(position, fillColor);
    
            for(var i=position.X-1;i<=position.X+1;i++)
                for (var j = position.Y - 1; j <= position.Y + 1; j++)
                {
                    var p = new Point(i, j);
                    fillStack.Push(p);
                }
    
        }
    
    }
   
