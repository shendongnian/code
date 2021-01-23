        int n;
        bool validNumber;
        do {
          validNumber = true;
          Console.Write("Enter the size of array:");
          if(!int.TryParse(Console.ReadLine(), out n)) // use TryParse instead of Parse to avoid formatting exceptions
          {
              Console.WriteLine("Not a number, please try again");
              validNumber = false;
          }
        } while(!validNumber);  // re-prompt if an invalid number has been entered
        int[] ar = new int[n];    // declare the array after the size is entered - your code will break if the user enters a number greater than 50
        // change to "string[] ar = new string[n];" if you want to keep the full value entered
        for (int i = 0; i < n; i++)
        {
            bool valid;
            do {
              valid = true;
              int num;
              string value = Console.ReadLine();
              if(int.TryParse(value, out num))  // again - use tryparse.
                ar[i] = num;  // change to "ar[i] = value;" if you're using a string array. 
              else {
                Console.WriteLine("Please enter that again - not a number");
                valid = false;
              }
           } while(!valid);
            
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("AR["+i+"]="+ar[i]);
        }
        Console.Read();
