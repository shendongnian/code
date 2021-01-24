    bool error;
    do
    {
    	Console.Write("\tBitte geben Sie ihre erste Zahl ein: ");
    	error = !double.TryParse(Console.ReadLine(), out zahl1); 
    	if (error)
    		Console.WriteLine("\tUngültige Eingabe. Bitte geben Sie nur Zahlen an!");
    } while(error);
