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
			List<int> listNumberSuite = new List<int>();
			List<int> listNumberDeck = new List<int>();
			int number;
			for(int i =0; i < 4; i++)
			{
				do {
					number = rand.Next(1, 4);
				} while (listNumberSuite.Contains(number));
				SuitEnum suit = (SuitEnum)number;
				int deckNumber;
				for(int j =0; j < 13; j++)
				{
					do {
						deckNumber = rand.Next(1, 13);
					} while (listNumberDeck.Contains(deckNumber));
					ValueEnum deck = (ValueEnum)deckNumber;
                    Cards.Add(new Card(suit, deck));
				}
			}
			foreach(Card c in Cards)
			{
				Console.WriteLine(c.Display());
			}
        }
	}
