         Dictionary<string, string> City = new Dictionary<string, string>();
         City.Add("Ind", "1");
         City.Add("Aus", "2");
         City.Add("Pak", "3");
         City.Add("Eng", "4");
         City.Add("USA", "5");
         while (true)
         {
            Console.WriteLine("Enter City name or Zipcode. Press x to Exit");
            var input = Console.ReadLine();
            if (input == "x")
               return;
            if (!City.TryGetValue(input, out string zipCode))
               Console.WriteLine("Invalid City");
            Console.WriteLine("Zipcode of {0} is:{1}", input, zipCode);
         }
