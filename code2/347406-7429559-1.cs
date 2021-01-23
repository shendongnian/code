    [XmlInclude(typeof(B))]
    [XmlInclude(typeof(C))]
    public class A
    {
        public int Value;
        public A() { }
        public A(int i) { Value = i; }
    }
    public class B : A
    {
        public double DoubleValue;
        public B() { }
        public B(int i, double d) : base(i) { DoubleValue = d; }
    }
    public class C : A
    {
        public string StringValue;
        public C() { }
        public C(int i, string s) : base(i) { StringValue = s; }
    }
    public class Container
    {
        public List<A> Items;
        public Container()
        {
            Items = new List<A>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Container container = new Container();
            container.Items.Add(new B(0, 1.3d));
            container.Items.Add(new B(1, 0.37d));
            container.Items.Add(new C(2, "c"));
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@"C:\TEMP\Container.xml"))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Container));
                serializer.Serialize(writer, container);
            }
        }
    }
