    public static IEnumerable<Box> GetBoxes(this IEnumerable<Box> boxes)
    {
        return boxes.Contents.SelectMany(b => GetBoxes(b));
    }
    
    public static Box GetBox(this IEnumerable<Box> boxes, int size)
    {
        return boxes.GetBoxesRecursive().FirstOrDefault(b => b.Size == size);
    }
