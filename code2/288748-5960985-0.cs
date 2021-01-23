    var counters = new[] { 1, 2, 4, 8 };
    var counters2 = counters;
    counters[0] = 2;
    counters[1] = 2;
    counters[2] = 3;
    counters[3] = 5;  // or use Array.Copy as suggested by Henrik
    Console.WriteLine(counters2[0].ToString()); // outputs 2
