     Console.WriteLine("Enter the first word");
     string word1 = Console.ReadLine();
     Console.WriteLine("Enter the second word");
     string word2 = Console.ReadLine();
     HashSet<char> processed = new HashSet<char>();
     int count = 0;
     foreach (char c in word1) 
       if (processed.Add(c))        // If c a new character  
         if (word2.IndexOf(c) >= 0) // and it's found within word2 
           count += 1;
     Console.WriteLine(count);
