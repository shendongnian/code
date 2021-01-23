    public class Trie
        {
            public struct Letter
            {
                public const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                public static implicit operator Letter(char c)
                {
                    c = c.ToString().ToUpper().ToCharArray().First();
    
                    return new Letter() { Index = Chars.IndexOf(c) };
                }
                public int Index;
                public char ToChar()
                {
                    return Chars[Index];
                }
                public override string ToString()
                {
                    return Chars[Index].ToString();
                }
            }
    
            public class Node
            {
                public string Word;
                public bool IsTerminal { get { return Word != null; } }
                public Dictionary<Letter, Node> Edges = new Dictionary<Letter, Node>();
    
    
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
    
    
            public List<string> GetSuggestions(string word, int max)
            {
                List<string> outPut = new List<string>();
    
                var node = Root;
                int i = 0;
                foreach (var l in word)
                {
                    Node cNode;
                    if (node.Edges.TryGetValue(l, out cNode))
                    {
                        node = cNode;
                    }
                    else
                    {
                        if (i == word.Length - 1)
                            return outPut;
                    }
                    i++;
                }
    
                GetChildWords(node, ref outPut, max);
    
                return outPut;
            }
    
    
            public void GetChildWords(Node n, ref List<string> outWords, int Max)
            {
                if (n.IsTerminal && outWords.Count < Max)
                    outWords.Add(n.Word);
    
                foreach (var item in n.Edges)
                {
                    GetChildWords(item.Value, ref outWords, Max);
                }
            }
    
        }
