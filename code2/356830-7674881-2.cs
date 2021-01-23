    public class Trie
    {
        public class Node
        {
            public string Word;
            public bool IsTerminal { get { return Word != null; } }
            public Dictionary<Char, Node> Edges = new Dictionary<Char, Node>();
        }
        public Node Root = new Node();
        public Trie(string[] words)
        {
            for (int w = 0; w < words.Length; w++)
            {
                var word = words[w];
                var node = Root;
                for (int len = 1; len <= word.Length; len++)
                {
                    var letter = word[len - 1];
                    Node next;
                    if (!node.Edges.TryGetValue(letter, out next))
                    {
                        next = new Node();
                        if (len == word.Length)
                        {
                            next.Word = word;
                        }
                        node.Edges.Add(letter, next);
                    }
                    node = next;
                }
            }
        }
    }
    var words = new[] { "mis", "und", "un", "der", "er", "stand" };
    // You must sort them!
    Array.Sort(words);
    var tries = new Trie(words);
    List<List<string>> parts = new List<List<string>>();
    string str = "misunderstand";
    Action<int, List<string>, Trie.Node> recSplit = null;
    recSplit = (index, collectedParts, node) =>
    {
        var collectedPartsOrig = collectedParts;
        if (node.Word != null)
        {
            if (index != str.Length)
            {
                collectedPartsOrig = new List<string>(collectedPartsOrig);
            }
            collectedParts.Add(node.Word);
            if (index == str.Length)
            {
                parts.Add(collectedParts);
            }
            else
            {
                recSplit(index, collectedParts, tries.Root);
            }
        }
        if (index == str.Length)
        {
            return;
        }
        Trie.Node nextNode = null;
        if (node.Edges.TryGetValue(str[index], out nextNode))
        {
            recSplit(index + 1, collectedPartsOrig, nextNode);
        }
        return;
    };
    recSplit(0, new List<string>(), tries.Root);
