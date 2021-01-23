    static void Main(string[] args)
    {
    Console.WriteLine("Input a value n");
    string number = Console.ReadLine(); // read number
    int n = Convert.ToInt32(number); // converting to int
    
    Console.WriteLine("Do you want to calculate factorial or sum");
    Console.WriteLine("Enter F or S");
    string choose = Console.ReadLine(); // F or S
    
    int result = -1; // to view later
    
    if (choose == "f" || choose == "F")
    {
     result = 1;
     for (int i = n; i >= 1; i--) // loop for calculating factorial
       result *= i;
    }
    else if (choose == "s" || choose == "S")
    {
     result = 0;
     for (int i = n; i >= 1; i--) // loop for calculating sum
       result += i;
    }
    
    Console.WriteLine(result); // printing answer
    Console.WriteLine("Press any key to close...");
    Console.ReadLine();
    }
