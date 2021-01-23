    class Trie
        {
            private string __key;
            private string __value;
    
            private List<Trie> __children;
            public Trie(string key = "root", string value = "root_val")
            {
                this.__key = key;
                this.__value = value;
                this.__children = new List<Trie>();
            }
            public void Initialize(Dictionary<string, string> nodes, int keyLength = 1)
            {
                foreach (var node in nodes)
                {
                    this.Add(node, keyLength);
                }
            }
            public void Add(KeyValuePair<string, string> node, int keyLength = 1)
            {
                if (node.Key.Length == keyLength)
                {
                    this.__children.Add(new Trie(node.Key, node.Value));
                }
                else
                {
                    try
                    {
                        this.__children.First(ch => (ch.__key == node.Key) || (node.Key.Substring(0, keyLength) == ch.__key)).Add(node, keyLength + 1);
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Parent not found, key not added : " + node.Key);
                    }
                }
            }
        }
    var items = new Dictionary<string, string>
    {
        { "a", "First level item" },
        { "b", "First level item"},
        { "ad", "Second level item"},
        { "bv", "Second level item"},
        { "adf", "Third level item"},
        { "adg", "Third level item"},
        { "bvc", "Third level item"},
        { "bvr", "Third level item"}
    };
    
    var myTree = new Trie();
    myTree.Initialize(items);
