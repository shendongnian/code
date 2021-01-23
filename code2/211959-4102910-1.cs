    string input = Console.ReadLine();
    int value;
    // First we check the return value, which is a bool
    // indicating success or failure.
    if (int.TryParse(input, out value))
    {
        // On success, we also use the value that was parsed.
        Console.WriteLine(
            "You entered the number {0}, which is {1}.",
            value,
            value % 2 == 0 ? "even" : "odd"
        );
    }
    else
    {
        // Generally, on failure, the value of an out parameter
        // will simply be the default value for the parameter's
        // type (e.g., default(int) == 0). In this scenario you
        // aren't expected to use it.
        Console.WriteLine(
            "You entered '{0}', which is not a valid integer.",
            input
        );
    }
