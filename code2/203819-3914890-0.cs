    public void Func( int i, int j )
    {
        Console.WriteLine (String.Format ("i = {0}, j = {1}", i, j));
    }
    
    public void Func( int i )
    {
        Func (i, 4);
    }
    
    public void Func ()
    {
        Func (5);
    }
