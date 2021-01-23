    Console.WriteLine(Math.Round(0.5, 0).ToString()); // outputs 0 (!!)
    Console.WriteLine(Math.Round(1.5, 0).ToString()); // outputs 2
    Console.WriteLine(Math.Round(0.5 + 0.00000001, 0).ToString()); // outputs 1
    Console.WriteLine(Math.Round(1.5 + 0.00000001, 0).ToString()); // outputs 2
    Console.ReadKey();
