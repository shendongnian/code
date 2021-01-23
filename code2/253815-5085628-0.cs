		static List<string> Solve()
	{
		// Declaring a empty list of strings to hold our results up front.
		List<string> words = new List<string>();
		// I'm using set as the term for your grid of letters.
		string set = @"ABCD
					   EFGH
					   HIJK
					   LMNO";
		// i'm explicitly defining the dimensions, you need to figure this out.
		int sizeX = 4;
		int sizeY = 4;
		// i'm also specifying a maximum word length. you might find a word like 
		// supercalifragilisticexpialidocious, but i doubt it so lets not waste time.
		int maximumWordSize = 3;
		// first, our trie/wordlist/etc. assume `GetWordList()` gets a list of all
		// valid words with indicated number of characters.
		List<string> wordList = GetWordList(3);
		// second, we load a character array with the set.
		char[,] data = new char[sizeX, sizeY];
		string[] lines = set.Split('\n');
		for (int i = 0; i <= lines.Count() -1; i++)
		{
			string line = lines[i].Trim();
			for (int j = 0; j <= line.Length - 1; j++)
			{
				char[j,i] = lines[j];
			}
		}
		// third, we iterate over the data
		for(int x = 0; x <= sizeX - maximumWordSize; x++)
		{
			for (int y = 0; y <= sizeY - maximumWordSize; y++)
			{
				// check to see if we even have any words starting with our cursor
				var validWords = wordList.Where(w=>w.Contains(data[x,y]));
				if (validWords.Count() > 0)
				{
					// ok, we have words. continue on our quest!
					// (this is where your initial qualifier changes if you use a trie
					// or other search method)
					
					char[] characters = char[maximumWordSize];
					// search left
					for (int i = x; i <= x + maximumWordSize - 1; i++)
						characters[i] = data[i, y];
					words.AddRange(Search(characters, wordList));
					// search down
					for (int i = y + maximumWordSize - 1; i <= y; i--)
						characters[i] = data[x, y];
					words.AddRange(Search(characters, wordList));
					// search diagonal right
					for (int i = x; i <= x + maximumWordSize - 1; i++)
						for (int j = y + maximumWordSize - 1; j <= y; j--)
							characters[i] = data[i, j];
					words.AddRange(Search(characters, wordList));
					
					// search diagonal left
					for (int i = x; i <= x - MaximumWordSize + 1; i++)
						for (int j = y + maximumWordSize - 1; j <= y; j--)
							characters[i] = data[i, j];
					words.AddRange(Search(characters, wordList));
				}
			}
		}
		return words;
	}
	static List<string> Search(char[] Input, List<string> WordList)
	{
		List<string> result = new List<string>();
		string word = "";
		// find forwards
		for (int i = 0; i <= Input.Length - 1; i++)
		{
			word += Input[i];
			if (WordList.Contains(word))
				result.Add(word);
		}
		// find backwards
		Array.Reverse(Input);
		for (int i = 0; i <= Input.Length - 1; i++)
		{
			word += Input[i];
			if (WordList.Contains(word))
				result.Add(word);
		}
		return result;
	}
