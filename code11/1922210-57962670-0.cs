    private static string GetStringFromUser(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }
    private static double GetDoubleFromUser(string prompt)
    {
        double input;
        // double.TryParse attempts to convert a string into a double, and
        // it returns a bool that indicates success. If it's successful,
        // then the out parameter will contain the converted value. Here
        // we loop until we get a successful result, then we return the value.
        do
        {
            Console.Write(prompt);
        } while (!double.TryParse(Console.ReadLine(), out input));
        return input;
    }
    public static double GetBMI(double height, double weight)
    {
        return weight / Math.Pow(height, 2) * 703;
    }
    private static ConsoleKeyInfo GetKeyFromUser(string prompt)
    {
        Console.Write(prompt);
        var key = Console.ReadKey();
        Console.WriteLine();
        return key;
    }
    private static void Main()
    {
        string name = GetStringFromUser("Enter your name: ");
        double weight = GetDoubleFromUser("Enter your weight in pounds: ");
        double height = GetDoubleFromUser("Enter your height in inches: ");
        double bmi = GetBMI(height, weight);
        Console.WriteLine($"Thank you, {name}. Your BMI is: {bmi}");
        GetKeyFromUser("\n\nDone! Press any key to exit...");
    }
