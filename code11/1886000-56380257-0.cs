    Console.Write("\tBitte geben Sie ihre erste Zahl ein: ");
    while (!double.TryParse(Console.ReadLine(), out zahl1))
    {
        Console.WriteLine("\tUngültige Eingabe. Bitte geben Sie nur Zahlen an!");
        
        Console.Write("\tBitte geben Sie ihre erste Zahl ein: ");
    }
