    public void Initialize(IList<string> items)
    {
        if( items is null ) // requires c# 7 or higher
        { 
            throw new ArgumentNullException(nameof(items));
        }
        // rest of the code here
    }
