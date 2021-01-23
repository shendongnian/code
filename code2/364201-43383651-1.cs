    string[] Selection = {"First", "Second", "Third", "Fourth"};
    string Valid = "Third";    // You can change this to a Console.ReadLine() to 
        //use user input 
    int temp = Array.IndexOf(Selection, Valid); // it gets the index of 'Valid', 
                    // in our case it's "Third"
                if (temp > -1)
                    Console.WriteLine("Valid selection");
                }
                else
                {
                    Console.WriteLine("Not a valid selection");
                }
