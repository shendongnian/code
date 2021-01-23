    public Class1 : MyDynamicImpelementation {}
    public Class2 : MyDynamicImpelementation {}
    static Class
    {
        public void PropertyAccess(dynamic obj)
        {
            for (int i = 0; i < 10; i++)
                obj.Property = i;
        }
        public void Main(string[] args)
        {
            PropertyAccess(new Class1());
            PropertyAccess(new Class2());
        }
    }
