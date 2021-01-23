    public class Class1 : MyDynamicImpelementation {}
    public class Class2 : MyDynamicImpelementation {}
    static class Class
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
