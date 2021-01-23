    string[] lines = File.ReadAllLines("TwoNumbers.txt");
    int leastNumber = int.MaxValue;
    foreach (string line in lines)
    {
        int currentNumber = int.Parse(line);
        if (currentNumber < leastNumber)
        {
            leastNumber = currentNumber;
        }
    }
    Console.WriteLine("The least number is: " + leastNumber);
    Console.ReadLine();
