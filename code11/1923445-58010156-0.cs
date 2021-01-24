    Console.Write("Choose name for new table: ");
    string tables = Console.ReadLine();
    
    string tablesInDatabases = new string($"{dataBases[chooseDatabase] + tables}");
    
    List<string> tablesAsList = new List<string>();
