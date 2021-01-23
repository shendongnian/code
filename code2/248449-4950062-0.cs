    [Flags]
    enum SomeEnum
    {
        SomeValue = 0,
        SomeOtherValue = 1,
        SomeFinalValue = 2
    }
    public class Program
    {
        public static void Main()
        {
            // This is defined: SomeOtherValue | SomeFinalValue
            SomeEnum x = (SomeEnum)3;
            
            Console.WriteLine(x);
            
            // This is not (no bitwise combination of 0, 1, and 2 will produce 4)
            x = (SomeEnum)4;
            
            Console.WriteLine(x);
        }
    }
