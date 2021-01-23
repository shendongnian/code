    int input;
    while(!int.TryParse(Console.ReadLine(), ref input) || input < 1 || input > 3) {
        Console.WriteLine("Please enter a valid option!");
    }
    switch((Number)input)
