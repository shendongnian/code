            //maak een dictionary aan
            Console.WriteLine("Quiz");
            Dictionary<int, string> Questions =
                       new Dictionary<int, string>();
            //voeg vragen toe 
            //key koppelen aan vraag
            Questions.Add(11, "Vraag1");
            Questions.Add(12, "Vraag2");
            Questions.Add(13, "Vraag3");
            Questions.Add(14, "Vraag4");
            Questions.Add(15, "Vraag5");
            foreach (KeyValuePair<int, string> ele1 in Questions)
            {
                Console.WriteLine("{0} and {1}",
                          ele1.Key, ele1.Value);
            }
            List<int> keylist = new List<int>(); // they key list should be int, since keys are declared as integers in your dictionary
            keylist = Questions.Keys.ToList();
            Random rand = new Random();
            int countKeys = Questions.Keys.Count();
            int randomIndex = rand.Next(0,countKeys);
            
            Console.WriteLine(Questions.ElementAt(randomIndex).Key); //here you are giving a random index and getting the key that is holding that index
            Console.ReadKey();
