        static void Draw(int[] Deck) //Draw function
        {
            Random rand = new Random(); // randomizer
            List<int> drawnCards = new List<int>();
            while (drawnCards.Count < 5)
            {
                int pick = rand.Next(Deck.Count());
                int card = Deck[pick];
                // Check card has not already been drawn
                if(!drawnCards.Contains(card))
                {
                    drawnCards.Add(card);
                }
            }
            foreach(int card in drawnCards)
            {
                Console.WriteLine(card);
            }
        }
