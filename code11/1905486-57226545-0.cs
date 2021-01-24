    double result;
    do
    {
        Console.Write("Type in a number and then press enter: ");
    }
    while (!double.TryParse(Console.ReadLine(), out result));
    Console.WriteLine($"Thanks! {result}");
