    static int readInt(string prompt, int low, int high) 
    {
        // Keep on looping until we return a valid result
        while (true) 
        {
            // Or 
            // Console.WriteLine(prompt);  
            // string input = Console.ReadLine();
            string input = readString(prompt); 
           
            int result = 0; // initialization: let the compiler be happy
            if (!int.TryParse(input, out result)) // Do we have an syntactically invalid input?
              Console.WriteLine($"{input} is not a valid integer number");
            else if (result < low || result > high) // If result is valid; is it out of range? 
              Console.WriteLine($"{input} is out of [{low}..{high}] range");
            else // result is valid integer and within the ranges: time to return it
              return result; 
        }
    }
