    static IEnumerable<Box> GetBoxesRecursive(this IEnumerable<Box> boxes)
    {
        return box.Contents.SelectMany(b => GetBoxesRecursive(b));
    }
    
    Box GetBoxesRecursive(IEnumerable<Box> boxes, int size)
    {
        return boxes.GetBoxesRecursive().FirstOrDefault(b => b.Size == size);
    }
