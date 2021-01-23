    private readonly object monitor = new object();
    private int sharedVariable;
    public void MethodThatSetsVariable()
    {
        lock (monitor)
        {
            sharedVariable = 5;
        }
    }
    public void MethodThatReadsVariable()
    {
        int foo;
        lock (monitor)
        {
            foo = sharedVariable;
        }
        // Use foo now
    }
