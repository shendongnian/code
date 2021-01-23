    // Local variable - can't possibly change...
    int x = ...;
    int y;
    if (x == 5)
    {
        y = 1;
    }
    else if (x != 5) // The compiler *could* realize this is the inverse...
    {
        y = 2;
    }
    Console.WriteLine(y);
