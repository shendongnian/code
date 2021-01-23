    public static Rectangle[] Subtract(this Rectangle source, Rectangle[] subtractions)
    {
        Region tmp = new Region(source);
    
        foreach (var sub in subtractions)
        {
            tmp.Xor(sub);
        }
        Region src = new Region(source);
        src.Intersect(tmp);
        return src.GetRegionScans(new Matrix()).Select(Rectangle.Ceiling).ToArray();
    }
