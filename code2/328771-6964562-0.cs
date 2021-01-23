    while (!int.TryParse(Console.ReadLine(), out rating) || rating < 0 || rating > 5)
    {
        Console.WriteLine();
        Console.WriteLine("Invalid Input, please input an integer from 0 - 5");
        Console.Write("Please enter new rating:   ");
    }
