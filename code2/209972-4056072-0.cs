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
			for(int i = 0; i < words.Length; ++i)
			{
				for(int j = i; j < words.Length; ++j)
				{
					sb.Clear();
					for(int k = i; k <= j; ++k)
					{
						sb.Append(words[k]);
						if(k != j) sb.Append(' ');
					}
					SetRanking(sb.ToString(), words.Length - (j - i));
				}
			}
		}
		private void SetRanking(string phrase, int ranking)
		{
			int oldranking;
			if(_ranking.TryGetValue(phrase, out oldranking))
			{
				if(oldranking > ranking) _ranking[phrase] = ranking;
			}
			else
			{
				_ranking.Add(phrase, ranking);
			}
		}
		public int this[string phrase]
		{
			get { return _ranking[phrase]; }
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
