    public static Edges DetectEdgesCollision(Rectangle a, Rectangle b)
    {
        var result = Edges.None;
        if (a == b) return Edges.Identical;
        b.Intersect(a);
        if (b.IsEmpty) return Edges.None;
        if (a == b) return Edges.Covers;
        
        if (a.Top == b.Top && (a.Right >= b.Right && a.Left<=b.Left )) 
            result |= Edges.Top;
        if (a.Bottom == b.Bottom && (a.Right >= b.Right && a.Left<=b.Left ))
            result |= Edges.Bottom;
        if (a.Left == b.Left && (a.Bottom >= b.Bottom && a.Top <= b.Top)) 
            result |= Edges.Left;
        if (a.Right == b.Right && (a.Bottom >= b.Bottom && a.Top <= b.Top)) 
            result |= Edges.Right;
         
        return result == Edges.None ? Edges.Inside : result;
    }
