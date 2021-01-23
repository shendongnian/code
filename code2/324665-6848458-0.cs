    public StuffClass(string a, char b, int c)
    {
        _a = a;
        _b = b;
        _c = c;
    }
    public StuffClass(string a, char b)
       : this(a, b, 2) 
    {}
