    var tests = new string[]
        {
            "2019-01-01 12:00 pm",
            "2019-01-01 01:00 pm",
            "2019-01-01 02:30 pm",
            "2019-01-01 03:00 pm",
            "2019-01-01 03:30 pm"
        };
    var dates = tests.Select(s => DateTime.Parse(s));
    foreach (var d in dates)
    {
        var result = d.IsBetween(TimeSpan.Parse("13:00"), TimeSpan.Parse("15:00"));
        if (result)
        {
            Console.WriteLine("{0} is between 1:00 and 3:00", d);
        }
        else
        {
            Console.WriteLine("{0} is not between 1:00 and 3:00", d);
        }
    }
