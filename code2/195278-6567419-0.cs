    public class MyClass
    {
        readonly int field1;
        readonly double field2;
        public MyClass(int field1, double field2)
        {
            //put whatever initialization logic you need here...
            field1 = 10;
            field2 = 30.2;
        }
        public MyClass(int field1, double field2p1, double field2p2)
            : this(field1, (field2p1 + field2p2))
        {
            //put anything extra in here
        }
    }
