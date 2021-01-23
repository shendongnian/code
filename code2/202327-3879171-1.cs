    using System;
    
    class Test
    {
        static void Main()
        {
            var london = TimeZoneInfo.FindSystemTimeZoneById
                ("GMT Standard Time");
            var googleplex = TimeZoneInfo.FindSystemTimeZoneById
                ("Pacific Standard Time");
            
            var now = DateTimeOffset.UtcNow;
            TimeSpan londonOffset = london.GetUtcOffset(now);
            TimeSpan googleplexOffset = googleplex.GetUtcOffset(now);
            TimeSpan difference = londonOffset - googleplexOffset;        
            Console.WriteLine(difference);
        }
    }
