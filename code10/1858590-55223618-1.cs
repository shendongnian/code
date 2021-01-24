    public enum SuitEnum
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }
    public enum ValueEnum
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }
	
	public class Card
    {       
        SuitEnum Suit { get; set; }
        ValueEnum Value { get; set; }
        public Card(SuitEnum cardSuit, ValueEnum cardValue)
        {
            Suit = cardSuit;
            Value = cardValue;
        }
		
		public string Display()
		{
			return Suit + "" + Value.ToString();
		}
    }
	
        public class Deck
        {
            public List<Card> Cards { get; set; }
            public Deck()
            {
                Random rand = new Random();
                Cards = new List<Card>();
                List<int> possibleSuit = Enumerable.Range(1, 4).ToList();
                List<int> listNumberSuite = new List<int>();
                for (int i = 0; i < 4; i++)
                {
                    int index = rand.Next(0, possibleSuit.Count);
                    listNumberSuite.Add(possibleSuit[index]);
                    SuitEnum suit = (SuitEnum)possibleSuit[index];
                    possibleSuit.RemoveAt(index);
                    List<int> possibleDeck = Enumerable.Range(1, 13).ToList();
                    List<int> listNumberDeck = new List<int>();
                    for (int j = 0; j < 13; j++)
                    {
                        int indexDeck = rand.Next(0, possibleDeck.Count);
                        listNumberDeck.Add(possibleDeck[indexDeck]);
                        ValueEnum deck = (ValueEnum)possibleDeck[indexDeck];
                        Cards.Add(new Card(suit, deck));
                        possibleDeck.RemoveAt(indexDeck);
                    }
                }
                foreach (Card c in Cards)
                {
                    Console.WriteLine(c.Display());
                }
            }
        }
