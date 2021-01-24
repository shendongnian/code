 using System;
namespace ConsoleApp1
{
    class MyArray
    {
        static void Main(string[] args)
        {
            var array = new string[] { "rock", "paper", "scissors" };
            var rand = new Random();
            Console.WriteLine("Rock, paper, or scissors?");
            string rps = Console.ReadLine().ToLower().Trim();   // simple sanitation
            var aiResponse = rpsValues[rand.Next(array.Length)]; // this is the PC's response
            Console.WriteLine(" PC plays: {0}", aiResponse);
            // Now compare input to ai
            if(rps == aiResponse)
                Console.WriteLine("Draw!!!");
            else
            {
                bool win = false;
                switch (rps.ToLower())
                {
                    case "rock":
                        win = aiResponse == "scissors";
                    break;
                    case "paper":
                        win = aiResponse == "rock";
                    break;
                    case "scissors":
                        win = aiResponse == "paper";
                    break;
                    default:
                        throw new ApplicationException("invalid input, expected: rock, paper or scissors");
                }
                if(win)
                    Console.WriteLine("You win!");
                else
                    Console.WriteLine("You lose!");
            }
        }
}
