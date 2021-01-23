    string[] Selection = {"First", "Second", "Third", "Fourth"};
    string Valid = "Third";    // You can change this to a Console.ReadLine() to 
        use user input 
    int temp = Array.IndexOf(Selection, Valid);    // it gets the index of Valid 
        (in our case "Third")
                if (temp > -1)    // if less than -1, then it means it haven't 
                    found such index, as arrays are 0 based 
                {
                    Console.WriteLine("Valid selection");
                }
                else
                {
                    Console.WriteLine("Not a valid selection");
                }
