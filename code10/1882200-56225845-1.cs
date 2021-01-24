    int sum = 0;
    for (int i = 0; i < rows; i++)
    { 
        int[] numbers = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        sum += numbers.Sum(); //Calculate sum of all numbers in a row and add it to existing sum variable.
    //I do not know how to add the elements here
    }
    Console.WriteLine("Sum of all numbers" + sum); //print sum of all numbers i.e. 76
