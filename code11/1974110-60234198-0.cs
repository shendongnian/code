    [Flags]
    public enum Days
    {
        Sunday    = 0b_0000_0001,  // 1
        Monday   = 0b_0000_0010,  // 2
        Tuesday = 0b_0000_0100,  // 4
        Wednesday  = 0b_0000_1000,  // 8
        Thursday    = 0b_0001_0000,  // 16
        Friday  = 0b_0010_0000,  // 32
        Saturday    = 0b_0100_0000,  // 64
    }
    public class FlagsEnumExample
    {
        public static void Main()
        {
            var a = (Days)38;
            Console.WriteLine(a);
            // Output:
            // Monday, Tuesday, Friday
        }
    }
