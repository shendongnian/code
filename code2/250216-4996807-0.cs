    public void setX() {
        Console.Write("Enter a value for X (int): ");
        while (!int.TryParse(Console.ReadLine(), out x))
            Console.Write("The value must be of integer type, try again: ");
    }
