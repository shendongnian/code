    class Trie
        {
            private readonly string _key;
            private string _value;
            private List<Trie> _path;
            private List<Trie> _children;
            public Trie(string key = "root", string value = "root_val")
            {
                this._key = key;
                this._value = value;
                this._path = this._children = new List<Trie>();
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
                if (this._children.Count == 0 || !this._children.Any(ch => (node.Key.StartsWith(ch._key)) || (ch._key == node.Key)))
                {
                    //For any item that could be a child of newly added item
                    Predicate<Trie> possibleChildren = (Trie ch) => { return ch._key.StartsWith(node.Key); };
    
                    var newChild = new Trie(node.Key, node.Value);
                    newChild._children.AddRange(this._children.FindAll(possibleChildren));
    
                    this._children.RemoveAll(possibleChildren);
                    this._children.Add(newChild);
                }
                else
                {
                    this._children.First(ch => (ch._key == node.Key) || (node.Key.Substring(0, keyLength) == ch._key)).Add(node, keyLength + 1);
                }
            }
            public void Delete(string key, bool recursively = true)
            {
                var newChildren = new List<Trie>(this._children);
                foreach (var child in this._children)
                {
                    if (child._key == key)
                    {
                        if (!recursively)
                        {
                            newChildren.AddRange(child._children);
                        }
                        newChildren.Remove(child);
                    }
                    else
                    {
                        child.Delete(key, recursively);
                    }
                }
    
                this._children = newChildren;
            }
            public List<Trie> Find(string key, int keyLength = 1)
            {
                this._path = new List<Trie>();
    
                if (key.Length >= keyLength - 1 && this._key == key.Substring(0, keyLength - 1))
                {
                    this._path.Add(this);
                }
                foreach (var child in this._children)
                {
                    var childPath = child.Find(key, keyLength + 1);
                    this._path.AddRange(childPath);
                }
    
                return this._path;
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
