	static int[] GetShuffledDeck()
	{
		int[] deck = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
		
		var rnd = new Random();
		var shuffledDeck = deck.OrderBy(x => rnd.Next()).ToArray();
		
		return shuffledDeck;
	}
	static void Main(string[] args)
	{	
		var shuffledDeck = GetShuffledDeck();
		
		Console.WriteLine("Draw 5 cards? Y/N");
		string ans = "";
		int counter = 0;
		
		while (!ans.Equals("N"))
		{
			ans = Console.ReadLine();
			if (ans.Equals("Y"))
			{
				Draw(shuffledDeck, ref counter);
				
				if (counter == 15)
				{
					// re-shuffle deck
				}
			}
			else
			{
				Console.WriteLine("Closing program");
			}
		}
	}
	
	static void Draw(int[] deck, ref int counter)
	{
		int turncount = 0;
		while (turncount < 5)
		{
			int pick = counter++;
			Console.WriteLine(Deck[pick]);
			turncount++;
		}
	}
