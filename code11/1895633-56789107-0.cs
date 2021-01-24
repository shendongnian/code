	public class Trie : Dictionary<char, Trie>
	{
		public void Add(string value)
		{
			var c = String.IsNullOrEmpty(value) ? '\0' : value[0];
			if (!this.ContainsKey(c))
			{
				this[c] = new Trie();
			}
			if (c != '\0')
			{
				this[c].Add(value.Substring(1));
			}
		}
	}
