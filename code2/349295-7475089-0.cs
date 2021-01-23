    using System.Linq;
    public Trie(List<string> words)
    {
        Root = new TrieNode('^', false, new List<TrieNode>());
        // Might have gotten the wrong method, check with intellisense
        char[] letters = words.SelectMany( word => word.ToCharArray());
        RecursiveAdd(letters, Root, 0);
    }
    private const int desiredDepth = 5;
    private void RecursiveAdd(char[] letters, TrieNode branch, currentDepth)
    {
        foreach(char letter in letters) {
            TrieNode node = new TrieNode(Letter, false, new List<TrieNode>());
            branch.Children.Add(node);
            if( currentDepth < desiredDepth ) {
                RecursiveAdd(letters, node, currentDepth+1);
            }
        }
    }
