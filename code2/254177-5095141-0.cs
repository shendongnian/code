    #define DEBUG
    //...
    #if DEBUG
    public int PublicMethod(int x, int y)
    {
        return privateMethod(x, y);
    }
    #endif
