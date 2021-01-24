    public float GetNumberFromUser()
    {
        float result;
        while (!float.TryParse(Console.ReadLine(), out result))
        {
            System.Console.WriteLine("Please enter a valid number...");
        }
        return result;
    }
