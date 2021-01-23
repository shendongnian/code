    DateTime dateTime = DateTime.Now;
    DateTime other = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
    // note that dateTime.ToUniversalTime() != other, unless local is UTC :)
    Console.WriteLine(dateTime + " " + dateTime.Kind); // 6/1/2011 4:14:54 PM Local
    Console.WriteLine(other + " " + other.Kind);       // 6/1/2011 4:14:54 PM Utc
