    public static IEnumerable<Box> GetBoxes(this Box box)
    {
    	return box.Contents.SelectMany(b => GetBoxes(b));
    }
    
    public static Box GetBox(this Box box, int size)
    {
    	return box.GetBoxes().FirstOrDefault(b => b.Size == size);
    }
