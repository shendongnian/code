    enum Test
    {
        Value1,
        Value2,
        Value3
    }
    static class TextExtensions
    {
        public static string Value(this Test value)
        {
            string stringValue = default(String);
            switch (value)
            {
                case Test.Value1:
                    {
                        stringValue = "some value 1";
                    } break;
                case Test.Value2:
                    {
                        stringValue = "some value 2";
                    }; break;
                case Test.Value3:
                    {
                        stringValue = "some value 3";
                    }; break;
            }
            return stringValue;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(Test.Value1.Value());
            Console.ReadLine();
        }
    }
