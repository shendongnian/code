    public static bool Execute()
    {
        if (something)
        {
            // do whatever
            return true;
        }
        return false;
    }
    public static void Main(string[] args)
    {
        while (!Execute())
        {
            // Empty
        }
    }
