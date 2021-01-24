    // here you receive your employee id
    Console.Write("Please enter your employee ID:"); empID = Console.ReadLine();
    
    string pattern = @"^\d{9}[A-Z]{1}$";
    
    // here you initialize your match variable by result of matching with regex
    Match match = Regex.Match(empID, pattern);
    while (match.Success != true)
    {
        if (match.Success == true)
        {
            Console.WriteLine(empID);
        }
        else
        {
            Console.WriteLine("Incorrect employee ID - please try again");
    
            // here you read your new employee id, but match variable is not updated
            empID = Console.ReadLine();
    
            // this is what you missed
            match = Regex.Match(empID, pattern);
        }
    }
