	public class PhraseRanking : IEnumerable<KeyValuePair<string, int>>
	{
		private readonly Dictionary<string, int> _ranking;
		public PhraseRanking()
		{
			_ranking = new Dictionary<string, int>();
		}
		public PhraseRanking(string phrase)
			: this()
		{
			var words = phrase.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			var sb = new StringBuilder(phrase.Length);
			for(int i = words.Length; i > 0; --i)
			{
				int rank = words.Length - i + 1;
				int lastFirstWordIndex = words.Length - i;
				for(int j = 0; j <= lastFirstWordIndex; ++j)
				{
					sb.Clear();
					int lastWordIndex = j + i - 1;
					for(int k = j; k <= lastWordIndex; ++k)
					{
						sb.Append(words[k]);
						if(k != lastWordIndex) sb.Append(' ');
					}
					_ranking[sb.ToString()] = rank;
				}
			}
		}
		public int this[string phrase]
		{
			get { return _ranking[phrase]; }
		}
		public int Count
		{
			get { return _ranking.Count; }
		}
		public IEnumerator<KeyValuePair<string, int>> GetEnumerator()
		{
			return _ranking.GetEnumerator();
		}
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return _ranking.GetEnumerator();
		}
	}
