    static void Main(string[] args)
    {
        var result = calc(33, 1, 10);
    
        Console.WriteLine(result);
        Console.ReadLine();
    }
    
    static double calc(double startingValue, double valueToSubtract, int numberOfTimes)
    {
        if (numberOfTimes == 0)
            return startingValue;
        return calc(startingValue - valueToSubtract, valueToSubtract, numberOfTimes - 1);
    }
