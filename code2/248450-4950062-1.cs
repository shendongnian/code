    [Flags]
    enum SomeEnum
    {
        SomeValue = 1,
        SomeOtherValue = 2,
        SomeFinalValue = 4
    }
    public class Program
    {
        public static void Main()
        {
            // This is defined.
            SomeEnum x = SomeOtherValue | SomeFinalValue;
            
            Console.WriteLine(x);
            
            // This is not (no bitwise combination of 1, 2, and 4 will produce 8).
            x = (SomeEnum)8;
            
            Console.WriteLine(x);
        }
    }
