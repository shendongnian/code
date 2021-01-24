    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace CardGame
    {
        class Program
        {
    		static List<int> cleanDeck = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }; // the deck
            static void Main(string[] args)
            {
                string ans = " ";
                List<int> Deck = cleanDeck;
    
                Console.WriteLine("Draw 5 cards? Y/N");
    
    
                while (!ans.Equals("N"))
                {
    
                    ans = Console.ReadLine();
    
                    if (ans.Equals("Y"))
                    {
                        Draw(Deck);
                    }
    
                    else
                    {
                        Console.WriteLine("Closing program");
                    }
                }
            }
    
            static void Draw(int[] Deck) //Draw function
            {
                Random rand = new Random(); // randomizer
                int turncount = 1;
    			if (Deck.Count() == 0) Deck = cleanDeck; // reinit the deck if empty
                while (turncount <= 5)
                {
                    int pick = rand.Next(Deck.Count()); // random pick for each iteration
                    Console.WriteLine(Deck[pick]);
    				Deck.removeAt(pick); // remove element
                    turncount++;
                }
            }
        }
    }
