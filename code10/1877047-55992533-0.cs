    using System;
    using System.Globalization;
    
    class Program
    {
        static void Main()
        {
            string text = "2019-05-03T00:00:00.000Z";
            DateTime parsed = DateTime.ParseExact(
                text, // The value to parse
                // The pattern to use for parsing
                "yyyy-MM-dd'T'HH:mm:ss.FFF'Z'",
                // Use the invariant culture for parsing
                CultureInfo.InvariantCulture,
                // Assume it's already in UTC, and keep it that way
                DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
    
            Console.WriteLine(parsed);  // 03/05/2019 00:00:00 (on my machine; format will vary)
            Console.WriteLine(parsed.Kind); // Utc
        }
    }
