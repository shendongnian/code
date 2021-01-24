    public class DeckOfCards
    {
    	public List<SingleCard> SingleDeck { get; private set; } = new List<SingleCard>();
    
    	public List<SingleCard> ShuffledDeck { get; private set; }
    
    	// create a single random generator ONCE and leave active.  This to help prevent
    	// recreating every time you need to shuffle and getting the same sequences.
    	// make static in case you want multiple decks, they keep using the same randomizing object
    	private static Random rndGen = new Random();
    
    	public DeckOfCards()
    	{
    		// build the deck of cards once...
    		// Start going through each suit
    		foreach (CardSuit s in typeof(CardSuit).GetEnumValues())
    		{
    			// now go through each card within each suit
    			foreach (CardFace f in typeof(CardFace).GetEnumValues())
    				// Now, add a card to the deck of the suite / face card
    				SingleDeck.Add(new SingleCard { Face = f, Suit = s });
    		}
    
    		// so now you have a master list of all cards in your deck declared once...
    	}
    
    	public void ShuffleDeck()
    	{
    		// to shuffle a deck, assign the next random number sequentially to the deck.
    		// don't just do random of 52 cards, but other to prevent duplicate numbers
    		// from possibly coming in
    		foreach (var oneCard in SingleDeck)
    			oneCard.RndNumber = rndGen.Next(3901);  // any number could be used...
    
    		// great, now every card has a randomized number assigned.
    		// return the list sorted by that random number...
    		ShuffledDeck = SingleDeck.OrderBy( o => o.RndNumber).ToList();
    	}
    
    	public void DisplayTheCards( List<SingleCard> theCards )
    	{
    		// show the deck of cards, or a single person's hand of cards
    		var sb = new StringBuilder();
    		foreach (var c in theCards)
    			sb = sb.AppendLine( c.NameOfCard );
    
    		MessageBox.Show(sb.ToString());
    	}
    
    	public void ConsoleDisplayTheCards(List<SingleCard> theCards)
    	{
    		// show the deck of cards, or a single person's hand of cards
    		foreach (var c in theCards)
    			Console.WriteLine(c.NameOfCard);
    	}
    
    
    	public List<List<SingleCard>> DealHands( int Players, int CardsPerHand )
    	{
    		// create a list of how many hands to be dealt...
    		// each player hand will consist of a list of cards
    		var Hands = new List<List<SingleCard>>(Players);
    
    		// prepare every players hand before dealing cards
    		for (var curPlayer = 0; curPlayer < Players; curPlayer++)
    			// each player gets their own list of cards
    			Hands.Add( new List<SingleCard>());
    
    
    		// prepare card sequence to deal
    		var nextCard = 0;
    		// loop for as many cards per hand
    		for (var oneCard = 0; oneCard < CardsPerHand; oneCard++)
    		{
    			// loop every player gets a card at a time vs one player gets all, then next player
    			for (var curPlayer = 0; curPlayer < Players; curPlayer++)
    				// add whatever the next card is to each individual's hand
    				Hands[curPlayer].Add(ShuffledDeck[nextCard++]);
    		}
    
    		return Hands;
    	}
    
    
    
    }
