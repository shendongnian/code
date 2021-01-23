    object ex1 = "True";
    Console.WriteLine(Convert.ToBoolean(ex1)); // True
    Console.WriteLine(bool.Parse(ex1.ToString())); // True
    object ex2 = "true";
    Console.WriteLine(Convert.ToBoolean(ex2)); // True
    Console.WriteLine(bool.Parse(ex2.ToString())); // True
    object ex3 = 1;
    Console.WriteLine(Convert.ToBoolean(ex3)); // True
    Console.WriteLine(bool.Parse(ex3.ToString())); // Unhandled Exception: System.FormatException
    object ex3 = "1";
    Console.WriteLine(Convert.ToBoolean(ex3)); // An unhandled exception of type 'System.FormatException' occurred
    Console.WriteLine(bool.Parse(ex3.ToString())); // Unhandled Exception: System.FormatException
    object ex4 = "False";
    Console.WriteLine(Convert.ToBoolean(ex4)); // False
    Console.WriteLine(bool.Parse(ex4.ToString())); // False
    object ex5 = "false";
    Console.WriteLine(Convert.ToBoolean(ex5)); // False
    Console.WriteLine(bool.Parse(ex5.ToString())); // False
    object ex6 = 0;
    Console.WriteLine(Convert.ToBoolean(ex6)); // False
    Console.WriteLine(bool.Parse(ex6.ToString())); // Unhandled Exception: System.FormatException
    object ex7 = null;
    Console.WriteLine(Convert.ToBoolean(ex7)); // False
    Console.WriteLine(bool.Parse(ex7.ToString())); // Unhandled Exception: System.NullReferenceException
