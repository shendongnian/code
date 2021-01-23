    static void Show(double average)
    {
        Console.WriteLine("The average is: {0}", average);
    }
    static void Main()
    {
        double avg = FindAverage();
        Show(avg);
        Console.ReadKey();
    }
