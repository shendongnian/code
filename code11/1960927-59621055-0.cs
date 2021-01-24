        bool res;
        Console.WriteLine("Enter a made up password:");
        string madeUppw = Console.ReadLine();
        foreach(char s in madeUppw){
           res = Char.IsSymbol(s);//The char.issymbol takes characters as parameter 
        }
