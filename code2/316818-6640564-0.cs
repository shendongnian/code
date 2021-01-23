    int num;
    Console.WriteLine("Please input age: ");
    if (!int.TryParse(Console.ReadLine(), out num))
    {
        Console.WriteLine("Please enter a valid age");
    }
    else
    {
        Console.WriteLine(num);
    }
