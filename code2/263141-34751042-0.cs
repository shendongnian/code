            // nonsensical, caused by mixing types
            DateTime dt = DateTime.Today - TimeSpan.FromHours(3);  // when on today??
            
            // strange edge cases, caused by impact of Kind
            var london = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            var paris = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");
            var dt = new DateTime(2016, 3, 27, 2, 0, 0);  // unspecified kind
            var delta = paris.GetUtcOffset(dt) - london.GetUtcOffset(dt);  // side effect!
            Console.WriteLine(delta.TotalHours); // 0, when should be 1 !!!
