    static void Main(string[] args)
    {
        FileAttributes newAttributes = File.GetAttributes(@"c:\blah");
        newAttributes = newAttributes & (~FileAttributes.Hidden);
    
        File.SetAttributes(@"c:\blah", newAttributes);
    }
