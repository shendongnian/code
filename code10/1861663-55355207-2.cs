       int[,] arr = new int[3, 3] {
          {1, 2, 6 }, 
          {4, 1, 5 }, 
          {6, 1, 8 }
       };
    
       HashSet<int> unique = new HashSet<int>();
    
       foreach (var item in arr)
         if (!unique.Add(item))
           Console.WriteLine(item);  // Not unique, print it out
