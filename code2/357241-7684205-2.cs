    public MyClass(string s) : this(ConstructorHelper(s))
    {
    }
    public MyClass(MyBigObject x)
    {
       this.o = x;
    }
    private static MyBigObject ConstructorHelper(string s)
    {
        int k = s.Length;
        int l = SomeFunction(s);
        int m = GetNumber();
        if (Valid(l, m))
        {
           int p = SomeOtherFunction(k, m);
           MyBigObject o = new MyBigObject(p);
           return o;
        }
        return null;
    }
