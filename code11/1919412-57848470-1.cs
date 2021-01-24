    public class SingleCard
    {
    	public CardFace Face { get; set; }
    	public CardSuit Suit { get; set; }
    	// place-holder for randomizing cards
    	public int RndNumber { get; set; }
    	// return the name of the card based on it's parts as single string
    	public string NameOfCard { get { return $"{Face} of {Suit}"; } }
    }
