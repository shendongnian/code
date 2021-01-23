    public static IEnumerable<Box> GetBoxes(this Box box)
    {
        // avoid NullReferenceException
    	var contents = box.Contents ?? Enumerable.Empty<Box>();
        // do the recursion
    	return contents.SelectMany(b => b.GetBoxes()).Concat(contents);
    }
