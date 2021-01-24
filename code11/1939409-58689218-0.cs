    static void Main(string[] args)
    {
        try 
        {
            AllocateALotOfMemory();
        }
        catch (OutOfMemoryException e)
        {
            // Handle error
        }
    }
