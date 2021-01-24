    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp2
    {
        class Program
        {
            public List<int> InputNumbers { get; set; }
            public List<int> RandomNumbers { get; set; }
            public List<int> MatchedNumbers { get; set; }
    
            Program()
            {
                //Instantiate your objects
                InputNumbers = new List<int> { 12,25,15,16,18,19 };
                RandomNumbers = new List<int> { 14, 15, 16, 17, 18, 19, 20 };
                MatchedNumbers = new List<int>(); //To hold Matched Values
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
                            result.Add(InputNumbers[i]);
                        }
                    }
                }
    
                //At this point, all matched numbers are organized in result object
                return result; //return result object
            }
    
            static void Main(string[] args)
            {
                Program App = new Program();
    
                //Evaluate the Numbers 
                App.MatchedNumbers = App.EvaluateMatches(App.InputNumbers, App.RandomNumbers);
    
                Console.WriteLine($"There were {App.MatchedNumbers.Count} Matched!");
                if(App.MatchedNumbers.Count > 0)
                {
                    Console.WriteLine("Below are the Numbers Matched:");
                    foreach(int Number in App.MatchedNumbers)
                    {
                        Console.Write($"{Number}  ");
                    }
                }
    
                Console.Write("\n");
                Console.WriteLine("Press any Key to Exit!");
                Console.ReadKey();
    
            }
        }
    }
