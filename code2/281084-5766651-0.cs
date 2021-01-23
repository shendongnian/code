    private Action<object> MainFunction;
    private Random rand = new Random();
    public static void Main(string[] args)
    {
        switch (rand.Next(3))
        {
            case 0: MainFunction = a; break;
            case 1: MainFunction = b; break;
            case 2: MainFunction = c; break;
        }
        MainFunction(null);
    }
