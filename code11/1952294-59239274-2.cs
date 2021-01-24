            int userInput = Convert.ToInt32(Console.ReadLine());
            var result = dictionary.ContainsKey(userInput);
            if(!result)
                Console.WriteLine("Wrong Input");
            else
            {
                var book = dictionary.FirstOrDefault(x => x.Key == userInput);
                Console.WriteLine("You chose book = {0}", book.Value);
            }
              
