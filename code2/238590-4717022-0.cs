    Dictionary<string, double> Counters = new Dictionary<string, double>();
    // Then initialize it ...
    Counters.Add("Humidity", 0);
    Counters.Add("Temp", 0);
    // To update:
    Counters["Humidity"] = 0.9;
    // To query
    double humidity = Counters["Humidity"];
