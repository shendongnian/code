    // Loop from .5 to 10 in increments of .5 (the 'M' signifies that the number is a decimal)
    for (decimal i = .5M; i <= 5; i += .5M)
    {
        Console.Write($"{i:0.0}: ");
        // First write out our "whole" stars
        for (int j = 0; j < (int) i; j++)
        {
            Console.Write("()");
        }
        // Then, if needed, write out the "half" stars
        if (i % 1 >= .5M) Console.Write("(");
        Console.WriteLine();
    }
    GetKeyFromUser("\n\nDone! Press any key to exit...");
