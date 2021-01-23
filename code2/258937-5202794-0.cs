    public class FakeEnum
    {
        public class EnumTypes
        {
            public abstract class BaseEnum
            {
                public abstract int Value { get; }
            }
            
            public class Value1 : BaseEnum
            {
                public override int Value
                {
                    get { return 1; }
                }
            }
            public class Value2 : BaseEnum
            {
                public override int Value
                {
                    get { return 2; }
                }
            }
        }
        public static class EnumValues
        {
            // Singletons
            public static readonly EnumTypes.Value1 Value1 = new EnumTypes.Value1();
            public static readonly EnumTypes.Value2 Value2 = new EnumTypes.Value2();
        }
        public void AcceptValue(EnumTypes.Value1 typeController, string s)
        {
            Console.WriteLine("Value1 " + s);
        }
        public void AcceptValue(EnumTypes.Value2 typeController, int i)
        {
            Console.WriteLine("Value2 " + i);
        }
        public void Test()
        {
            AcceptValue(EnumValues.Value1, "with value1"); // valid
            AcceptValue(EnumValues.Value2, 1); // valid
            //AcceptValue(EnumValues.Value1, 4); // Invalid, compile error
        }
    }
