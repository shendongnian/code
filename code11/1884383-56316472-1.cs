    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApp2
    {
        class Program
        {
            public List<List<int>> Players { get; set; } //Your Players
            public List<int> RandomNumbers { get; set; } //Your Random numbers enerated my Computer
            public List<List<int>> MatchedNumbers { get; set; } //to store Matched Numbers for each player
            public int NumbersRequiredCount { get; set; } = 7; //Depends on how many numbers the players must guess, initialize to 7 numbers
    
            Program()
            {
                //Instantiate your objects
                Players = new List<List<int>>(); //List of Players with their list of guessed numbers
                RandomNumbers = new List<int>(); 
                MatchedNumbers = new List<List<int>>(); //To hold Matched Values
            }
    
            private List<int> GenerateAutoNumbers(int Count, int Min, int Max)
            {
                var Result = new List<int>(); //Result Container - will be returned
                var Random = new Random(); //Create Random Number Object
                for(int i = 0; i < Count; i++)
                {
                    //Generate your random number and save
                    Result.Add(Random.Next(Min, Max));
                }
                //Return "Count" Numbers of Random Numbers generated
                return Result;
            }
    
            public List<int> EvaluateMatches(List<int> Inputs, List<int> Bases)
            {
                var result = new List<int>();
                //Inplement a counter to check each value that was inputted
                for(int i = 0; i <  Inputs.Count; i++)
                {
                    for (int r = 0; r < Bases.Count; r++)
                    {
                        //Check if the current input equals the current Random Number at the given index
                        if(Inputs[i] == Bases[r])
                        {
                            //If matched. Add the matched number to the matched list
                            result.Add(Inputs[i]);
                        }
                    }
                }
    
                //At this point, all matched numbers are organized in result object
                return result; //return result object
            }
    
            static void Main(string[] args)
            {
                Program App = new Program();
    
                //Players must input numbers - Assuming they must guess between 1 - 100
                //It can be as many players
    
                //Player 1
                App.Players.Add(new List<int> { 5, 47, 33, 47, 36, 89, 33 });
                //Player 2
                App.Players.Add(new List<int> { 1, 17, 38, 43, 34, 91, 24 });
                //Player 3
                App.Players.Add(new List<int> { 6, 74, 39, 58, 52, 21, 9 });
    
                //At this point the inputs are all in for the 3 players
                //Now generate your RandomNumbers
                App.RandomNumbers = App.GenerateAutoNumbers(App.NumbersRequiredCount, 1, 100);
    
                //Now you need to evaluate the guessed numbers
                //For each Player
                for(int p = 0; p < App.Players.Count; p++)
                {
                    //Create the list for each user to hold the matched numbers
                    App.MatchedNumbers.Add(App.EvaluateMatches(App.Players[p], App.RandomNumbers));
                }
    
                //Now all Players numbers are evaluated, all you need is to print the results
                Console.WriteLine("Results has been retrieved");
                Console.Write("Generated Numbers are: ");
                foreach(int i in App.RandomNumbers)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
                Console.WriteLine();
    
                Console.WriteLine("Following Matches were Found: ");
                for(int p = 0; p < App.Players.Count; p++)
                {
                    Console.Write($"Player {p + 1} has {App.MatchedNumbers[p].Count} Matches: ");
                    foreach(int i in App.MatchedNumbers[p])
                    {
                        Console.Write(i + "  ");
                    }
                    Console.WriteLine();
                }
                Console.Write("\n");
                Console.WriteLine("Press any Key to Exit!");
                Console.ReadKey();
    
            }
        }
    }
