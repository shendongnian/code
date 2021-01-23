    public MyClass(string s)
    {
        int k = s.Length;
        int l = SomeFunction(s);
        int m = GetNumber();
        if (Valid(l, m))
        {
           int p = SomeOtherFunction(k, m);
           MyBigObject o = new MyBigObject(p);
           this.init(o);
        }
    }
    
    public MyClass(MyBigObject x)
    {
       this.init(x);
    }
    
    public void init(MyBigObject x)
    {
       this.o = x;
    }
