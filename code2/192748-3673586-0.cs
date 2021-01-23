        const double COMMRATE = 0.10;
        string inputstring;
        double sales;
        char response;
        Console.Write("Do you want to Calculate Sales A or B or E...");
        inputstring = Console.ReadLine();
        response = Convert.ToChar(inputstring);
        while (response == 'A') 
        {
            Console.WriteLine("Enter Sales");
            inputstring = Console.ReadLine();
            sales = Double.Parse(inputstring);
            Console.WriteLine("Sales = " & sales);
            Console.WriteLine("Commission = " & sales * COMMRATE);
        }
