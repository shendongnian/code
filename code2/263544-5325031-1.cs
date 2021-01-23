    using System;
    using System.Globalization;
    class Test
    {
        static void Main()
        {
            decimal d;
            decimal.TryParse("22.00", NumberStyles.Any,
                             CultureInfo.InvariantCulture, out d);
            // This prints out 22.00
            Console.WriteLine(d.ToString(CultureInfo.InvariantCulture));
        }
    }
