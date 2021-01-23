    DateTime event1 = new DateTime(2011, 10, 11);
    DateTime event2 = new DateTime(2021, 10, 11);
    Action<DateTime> eventPointer;  // A Pointer?
    if (true)
    {
        eventPointer = x => { event1 = x; };
    }
    else
    {
        eventPointer = x => { event2 = x; };
    }
    eventPointer(new DateTime(2016, 10, 11));
    Console.WriteLine(event1.ToString(CultureInfo.InvariantCulture));
    Console.WriteLine(event2.ToString(CultureInfo.InvariantCulture));
