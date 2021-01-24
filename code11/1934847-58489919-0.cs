//string ResultsG1, ResultsG2, ResultsG3, ResultsG4, ResultsG5, ResultsG6;
            int games = 6;
            string[] results_per_game = new string[games];
            int resultsGameWeek = 1;
            List<int> Results = new List<int>();
            do
            {
                Console.Write("RG" + resultsGameWeek + "H: ");
                Results.Add(Convert.ToInt32(Console.ReadLine()));
                Console.Write("RG" + resultsGameWeek + "A: ");
                Results.Add(Convert.ToInt32(Console.ReadLine()));
                resultsGameWeek++;
            } while (resultsGameWeek <= games);
            int result1 = 0;
            int result2 = 0;
            for (int i = 0; i < games; i++)
            {
                result1 = Results[i * 2];
                result2 = Results[(i * 2) + 1];
                if (result1 > result2)
                {
                    Console.WriteLine("HW");
                    //ResultsG1 = "HW";
                    results_per_game[i] = "HW";
                }
                else if (result1 < result2)
                {
                    Console.WriteLine("AW");
                    //ResultsG6 = "AW";
                    results_per_game[i] = "AW";
                }
                else
                {
                    Console.WriteLine("D");
                    //ResultsG6 = "D";
                    results_per_game[i] = "D";
                }
            }
            for (int i = 0; i < results_per_game.Length; i++)
            {
                int nextResultGame = i + 1;
                Console.WriteLine("ResultsG" + nextResultGame + " = " + results_per_game[i]);
            }
            Console.ReadLine(); 
To iterate through the list with results, I used the formula "i*2" and "(i*2) + 1" to get the first and second result of each game, respectively. So, you'll get in a for iteration of 6 steps:
1. i = 0, position1 = i*2 = 0, position2 = (i*2) + 1 = 1. 
2. i = 1, position1 = i*2 = 2, position2 = (i*2) + 1 = 3.
3. i = 2, position1 = i*2 = 4, position2 = (i*2) + 1 = 5. 
4. i = 3, position1 = i*2 = 6, position2 = (i*2) + 1 = 7. 
5. i = 4, position1 = i*2 = 8, position2 = (i*2) + 1 = 9. 
6. i = 5, position1 = i*2 = 10, position2 = (i*2) + 1 = 11.  
Also, I managed the resultsG with an array the same length of the List of results, so I can iterate through this array to print the results too.
