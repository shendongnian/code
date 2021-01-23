    var trie = new Trie(new[] { "un", "que", "stio", "na", "ble", "qu", "es", "ti", "onable", "o", "nable" });
    //var trie = new Trie(new[] { "u", "n", "q", "u", "e", "s", "t", "i", "o", "n", "a", "b", "l", "e", "un", "qu", "es", "ti", "on", "ab", "le", "nq", "ue", "st", "io", "na", "bl", "unq", "ues", "tio", "nab", "nqu", "est", "ion", "abl", "que", "stio", "nab" });
    var word = "unquestionable";
    var parts = new List<List<string>>();
    Split(word, 0, trie, trie.Root, new List<string>(), parts);
    //
    public static void Split(string word, int index, Trie trie, TrieNode node, List<string> currentParts, List<List<string>> parts)
    {	
        // Found a syllable. We have to split: one way we take that syllable and continue from it (and it's done in this if).
		// Another way we ignore this possible syllable and we continue searching for a longer word (done after the if)
        if (node.IsTerminal)
        {
            // Add the syllable to the current list of syllables
            currentParts.Add(node.Word);
            // "covered" the word with syllables
            if (index == word.Length)
            {
                // Here we make a copy of the parts of the word. This because the currentParts list is a "working" list and is modified every time.
                parts.Add(new List<string>(currentParts));
            }
            else
            {
                // There are remaining letters in the word. We restart the scan for more syllables, restarting from the root.
                Split(word, index, trie, trie.Root, currentParts, parts);
            }
            // Remove the syllable from the current list of syllables
            currentParts.RemoveAt(currentParts.Count - 1);
        }
        // We have covered all the word with letters. No more work to do in this subiteration
        if (index == word.Length)
        {
            return;
        }
        // Here we try to find the edge corresponding to the current character
        TrieNode nextNode;
        if (!node.Edges.TryGetValue(word[index], out nextNode))
        {
            return;
        }
        Split(word, index + 1, trie, nextNode, currentParts, parts);
    }
    public class Trie
    {
        public readonly TrieNode Root = new TrieNode();
        public Trie()
        {
        }
        public Trie(IEnumerable<string> words)
        {
            this.AddRange(words);
        }
        public void Add(string word)
        {
            var currentNode = this.Root;
            foreach (char ch in word)
            {
                TrieNode nextNode;
                if (!currentNode.Edges.TryGetValue(ch, out nextNode))
                {
                    nextNode = new TrieNode();
                    currentNode.Edges[ch] = nextNode;
                }
                currentNode = nextNode;
            }
            currentNode.Word = word;
        }
        public void AddRange(IEnumerable<string> words)
        {
            foreach (var word in words)
            {
                this.Add(word);
            }
        }
    }
    public class TrieNode
    {
        public readonly Dictionary<char, TrieNode> Edges = new Dictionary<char, TrieNode>();
        public string Word { get; set; }
        public bool IsTerminal
        {
            get
            {
                return this.Word != null;
            }
        }
    }
