    static void Main(string[] args)
            {
                //initialize the array 
                var elements = new[]
                {
                    new Element("data x"),
                    new Element("data y"),
                    new Element("data z")
                };
    
                //pass the elements to the game
                var game = new Game(elements);
    
                //print the second element
                game.PrintElement(1);
    
                //print all elements
                game.PrintGameElements();
    
                Console.ReadKey();
            }
        }
