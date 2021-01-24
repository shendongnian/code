    static int ReadCoordinate(string message, int maxValue)
    {
        Console.WriteLine(message);
        var isValid = false;
        int value;
        do
        {
            isValid = int.TryParse(Console.ReadLine(), out value) && value > 0 && value <= maxValue;
            if (!isValid)
            {
                Console.WriteLine("Please try again.");
            }
        } while (!isValid);
        return value;
    }
