    class Program
    {
        
        static void Main(string[] args)
        {
            Random random = new Random(); 
            var cards = new List<string>();
            //CARDS VECRTOR
            String[] listas = new String[] { "Card 1", "Card 2", "Card 3", "Card 4", "Card 5", "Card 6", "Card 7"};
            for (int i = 0; i<= cards.Count; i++)
            {
                int number = random.Next(0, 7); //Random number 0--->7
            
                for (int j = 0; j <=6; j++)
                {
                    if (cards.Contains(listas[number])) // NO REPEAT SHUFFLE
                    {
                        number = random.Next(0, 7); //AGAIN RANDOM
                    }
                    else
                    {
                        cards.Add(listas[number]); //ADD CARD
                    }
                }
                   
            }
            Console.WriteLine(" LIST CARDS");
            foreach (var card in cards)
            {
                Console.Write(card + " ,");
            }
            Console.WriteLine("Total Cards: "+cards.Count);
           
            //REMOVE
            for (int k = 0; k <=6; k++)
            {
               // salmons.RemoveAt(k);
                Console.WriteLine("I take the card: "+cards.ElementAt(k));
                cards.RemoveAt(k); //REMOVE CARD
                cards.Insert(k,"Card Taken"); //REPLACE INDEX
                foreach (var card in cards)
                {
                    Console.Write(card + " " + "\n");
                }
               
            }
           
            Console.Read(); //just pause
  
        }
     
    }
