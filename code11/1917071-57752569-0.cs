       // Separated input like "1 2 3 45 6 789"
       // we don't have to materialize into array
       // let's be nice: allow tabulation as well as space,
       //                tolerate leading/trailing and double spaces: "  1   2 3 " 
       var numbers = Console
         .ReadLine() 
         .Split(new char[] { ' ', '\t'}, StringSplitOptions.RemoveEmptyEntries) // let's be nice
         .Select(item => int.Parse(item));
    
       int even = 0;
       int odd = 0;
     
       foreach (var number in numbers) {
         if (number % 2 != 0)    
           odd += number;
         else
           even += number;  
       }
    
       Console.WriteLine(even * odd);
