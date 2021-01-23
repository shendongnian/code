    public Rectangle[] Subtract(Rectangle[] subtractions)
    {// space to chop = this panel
        Region src = new Region(Bounds); 
        foreach (var sub in subtractions)
        {
            Region tmp = src.Clone();
            tmp.Xor(sub);
            src.Intersect(tmp);                
        }
        return src.GetRegionScans(new Matrix()).Select(Rectangle.Ceiling).ToArray();
    }
