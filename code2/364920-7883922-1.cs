        string Stored = "";
        for (int i=0; i < 5; i++;)
        {
            string input1;
            int iinput1, asteriskcount1;
            Console.WriteLine("Input number of sales please!");
            input1 = Console.ReadLine();
            //Adds to existing Stored value
            Stored += input1 + " is "; 
            //Adds asterisk
            iinput1 = Convert.ToInt32(input1);
            asteriskcount1 = iinput1 / 100;
            for(int j = 0; j < asteriskcount1; j++)
            {
                 Stored += "*";
            }
            //Adds Comma
            if(i != 4)
                 Stored += ",";
        }
        Console.WriteLine(Stored); //Print Result
