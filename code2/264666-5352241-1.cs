    public class Card
    {
    	public int Value { get; private set; }
    	public enum SuitType
    	{
    		Clubs, Spades, Hearts, Diamonds
    	}
    	public SuitType Suit { get; private set; }
    	public Card(int value, SuitType suit)
    	{
    		Suit = suit;
    		Value = value;
    	}
    	public Card(string input)
    	{
    		if (input == null || input.Length < 2 || input.Length > 2)
    			throw new ArgumentException();
    		switch (input[0])
    		{
    			case 'C': case 'c':
    				Suit = SuitType.Clubs;
    				break;
    			case 'S': case 's':
    				Suit = SuitType.Spades;
    				break;
    			case 'H': case 'h':
    				Suit = SuitType.Hearts;
    				break;
    			case 'D': case 'd':
    				Suit = SuitType.Diamonds;
    				break;
    			default:
    				throw new ArgumentException();
    		}
    		int uncheckedValue = (int)input[1];
    		if (uncheckedValue > 14 || uncheckedValue < 1)
    			throw new ArgumentException();
    		Value = uncheckedValue;
    	}
    	public string encode()
    	{
    		string encodedCard = "";
    		switch (Suit)
    		{
    			case SuitType.Clubs:
    				encodedCard += 'c';
    				break;
    			case SuitType.Spades:
    				encodedCard += 's';
    				break;
    			case SuitType.Hearts:
    				encodedCard += 'h';
    				break;
    			case SuitType.Diamonds:
    				encodedCard += 'd';
    				break;
    		}
    		encodedCard += (char) Value;
    		return encodedCard;
    	}
    	public override string ToString()
    	{
    		string output = "";
    		if (Value > 10)
    		{
    			switch (Value)
    			{
    				case 11:
    					output += "Jack";
    					break;
    				case 12:
    					output += "Queen";
    					break;
    				case 13:
    					output += "King";
    					break;
    				case 14:
    					output += "Ace";
    					break;
    			}
    		}
    		else
    		{
    			output += Value;
    		}
    		output += " of " + System.Enum.GetName(typeof(SuitType), Suit);
    		return output;
    	}
    }
