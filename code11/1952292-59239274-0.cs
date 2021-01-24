     int userInput = Convert.ToInt32(Console.ReadLine());
        var result = dictionary.FirstOrDefault(x => x.Key == userInput);
        if(result.Value != null)
            Console.WriteLine("You chose book = {0}", result.Value);
        else
            Console.WriteLine("Wrong Input");
