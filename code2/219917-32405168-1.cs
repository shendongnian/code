    private static string LoremIpsum(int minWords, int maxWords, int minSentences, int maxSentences, int numLines)
    {
        var words = new[]{"lorem", "ipsum", "dolor", "sit", "amet", "consectetuer", "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod", "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"};
        var rand = new Random();
        int numSentences = rand.Next(maxSentences - minSentences)
            + minSentences;
        int numWords = rand.Next(maxWords - minWords) + minWords;
        var sb = new StringBuilder();
        for (int p = 0; p < numLines; p++)
        {
            for (int s = 0; s < numSentences; s++)
            {
				for( int w = 0; w < numWords; w++ )
				{
					if( w > 0 ) { sb.Append( " " ); }
					string word = words[ rand.Next( words.Length ) ];
					if( w == 0 ) { word = word.Substring( 0, 1 ).Trim().ToUpper() + word.Substring( 1 ); }
					sb.Append( word );
				}
                sb.Append(". ");
            }
            if ( p < numLines-1 ) sb.AppendLine();
        }
        return sb.ToString();
    }
