    public foo (int x, int y) { Setup(x, y); }
    public foo (string s)
    {
       // do stuff
       int x = XFromString(s);
       int y = YFromString(s);
       Setup(x, y);
    }
    public void Setup(int x, int y) { ... }
