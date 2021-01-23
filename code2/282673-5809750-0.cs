    using (StreamReader sr = new StreamReader("addresses.txt")) 
    {
         string line;
         // Read and display lines from the file until the end of 
         // the file is reached.
         while ((line = sr.ReadLine()) != null) 
         {
             string[] tokens = line.Split(' ');
             // variant 1: Address FirstName Surname NHS No //Person1 Age = 44
             // variant 2: Address FirstName Surname NHS No //person 2 12345
             Console.Writeline("Address: ", tokens[0]);
             Console.Writeline("First name: ", tokens[1]);
             // etc.
         }
    }
