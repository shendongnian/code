            double total = 0;
            int input = -1;
            List<int> allInput = new List<int>();
            while (input != 0)
            {
                Console.Write("Enter your number: ");
                input = int.Parse(Console.ReadLine());
                allInput.Add(input); 
            }
            for (int i = 0; i < allInput.Count()-1; i += 5)
            {
                total = total + allInput[i];
            }
          
            Console.WriteLine("The sum of every +5 numbers is: {0}", total);
            Console.ReadKey();
