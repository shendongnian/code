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
            Random rand = new Random();
            int randomKey = Questions.Keys.OrderBy(x => rand.Next()).Single();
            Console.WriteLine(Questions[randomKey]);
             
            Console.ReadKey();
