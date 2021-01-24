    int sum = 0;
    for (int i = 0; i < rows; i++)
    { 
        int[] numbers = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        sum += numbers.Sum();
    //I do not know how to add the elements here
    }
    Console.WriteLine("Sum of all numbers" + sum);
