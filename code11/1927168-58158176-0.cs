    var previous = Console.Out; // backup current state
    var writer = new StringWriter();
    Console.SetOut(writer);
    GetFlightInfo(...);
    Console.SetOut(previous); // restore the original state
    string result = writer.ToString();
    Console.WriteLine(result);
