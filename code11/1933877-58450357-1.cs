    while(true) {
        System.Threading.Thread.Sleep(3000); // to waiting 3 seconds
        Console.WriteLine("Would you like to proceed ? (Y/N)");
        var option = Console.ReadKey();
    
        if (option.ToString().ToUpper() == "N"){
               Environment.Exit(0);
        }
    }
