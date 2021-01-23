    var listOfLists = new List<object> {
        new[] { AttributeTargets.All },
        new[] { ConsoleColor.Blue },
        new[] { PlatformID.Xbox, PlatformID.MacOSX },
        new[] { DayOfWeek.Friday, DayOfWeek.Saturday }
    };
    Console.WriteLine(listOfLists.Where(obj => obj.GetType() == typeof(DayOfWeek[])).Count());
