    // Output All Leaf Nodes From Root
    EnumerateDirectory(@"c:\");
    
    public void EnumerateDirectory(string baseDirectory)
    {
        if( Directory.GetDirectories(baseDirectory).Count == 0 )
        {
             // This is an end, leaf node.
             Output("This is a leaf node.");
             return;
        }
    
        foreach(var directory in Directory.GetDirectories(baseDirectory) )
        {
              EnumerateDirectory(directory);
              return;
        }
    }
