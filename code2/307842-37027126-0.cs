    /*
        Copyright (c) 2016 Scirra Ltd
        www.scirra.com
        Permission is hereby granted, free of charge, to any person obtaining a copy
        of this software and associated documentation files (the "Software"), to deal
        in the Software without restriction, including without limitation the rights
        to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
        copies of the Software, and to permit persons to whom the Software is
        furnished to do so, subject to the following conditions:
        The above copyright notice and this permission notice shall be included in all
        copies or substantial portions of the Software.
        THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
        IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
        FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
        AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
        LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
        OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
        SOFTWARE.
     */
    public class Trie
    {
        private class Node
        {
            public bool Terminal { get; set; }
            public Dictionary<char, Node> Nodes { get; private set; }
            public Node ParentNode { get; private set; }
            public char C { get; private set; }
    
            /// <summary>
            /// String word represented by this node
            /// </summary>
            public string Word
            {
                get
                {
                    var b = new StringBuilder();
                    b.Insert(0, C.ToString(CultureInfo.InvariantCulture));
                    var selectedNode = ParentNode;
                    while (selectedNode != null)
                    {
                        b.Insert(0, selectedNode.C.ToString(CultureInfo.InvariantCulture));
                        selectedNode = selectedNode.ParentNode;
                    }
                    return b.ToString();
                }
            }
    
            public Node(Node parent, char c)
            {
                C = c;
                ParentNode = parent;
                Terminal = false;
                Nodes = new Dictionary<char, Node>();
            }
    
            /// <summary>
            /// Return list of terminal nodes under this node
            /// </summary>
            public IEnumerable<Node> TerminalNodes(char? ignoreChar = null)
            {
                var r = new List<Node>();
                if (Terminal) r.Add(this);
                foreach (var node in Nodes.Values)
                {
                    if (ignoreChar != null && node.C == ignoreChar) continue;
                    r = r.Concat(node.TerminalNodes()).ToList();
                }
                return r;
            } 
        }
    
        private Node TopNode_ { get; set; }
        private Node TopNode
        {
            get
            {
                if (TopNode_ == null) TopNode_ = new Node(null, ' ');
                return TopNode_;
            }
        }
        private bool CaseSensitive { get; set; }
    
        /// <summary>
        /// Get list of all words in trie that start with
        /// </summary>
        public HashSet<string> GetAutocompleteSuggestions(string wordStart, int fetchMax = 10)
        {
            if(fetchMax <= 0) throw new Exception("Fetch max must be positive integer.");
    
            wordStart = NormaliseWord(wordStart);
    
            var r = new HashSet<string>();
    
            var selectedNode = TopNode;
            foreach (var c in wordStart)
            {
                // Nothing starting with this word
                if (!selectedNode.Nodes.ContainsKey(c)) return r;
                selectedNode = selectedNode.Nodes[c];
            }
    
            // Get terminal nodes for this node
            {
                var terminalNodes = selectedNode.TerminalNodes().Take(fetchMax);
                foreach (var node in terminalNodes)
                {
                    r.Add(node.Word);
                }
            }
    
            // Go up a node if not found enough suggestions
            if (r.Count < fetchMax)
            {
                var parentNode = selectedNode.ParentNode;
                if (parentNode != null)
                {
                    var remainingToFetch = fetchMax - r.Count;
                    var terminalNodes = parentNode.TerminalNodes(selectedNode.C).Take(remainingToFetch);
                    foreach (var node in terminalNodes)
                    {
                        r.Add(node.Word);
                    }
                }
            }
    
            return r;
        } 
    
        /// <summary>
        /// Initialise instance of trie with set of words
        /// </summary>
        public Trie(IEnumerable<string> words, bool caseSensitive = false)
        {
            CaseSensitive = caseSensitive;
            foreach (var word in words)
            {
                AddWord(word);
            }
        }
    
        /// <summary>
        /// Add a single word to the trie
        /// </summary>
        public void AddWord(string word)
        {
            word = NormaliseWord(word);
            var selectedNode = TopNode;
    
            for (var i = 0; i < word.Length; i++)
            {
                var c = word[i];
                if (!selectedNode.Nodes.ContainsKey(c))
                {
                    selectedNode.Nodes.Add(c, new Node(selectedNode, c));
                }
                selectedNode = selectedNode.Nodes[c];
            }
            selectedNode.Terminal = true;
        }
    
        /// <summary>
        /// Normalise word for trie
        /// </summary>
        private string NormaliseWord(string word)
        {
            if (String.IsNullOrWhiteSpace(word)) word = String.Empty;
            word = word.Trim();
            if (!CaseSensitive)
            {
                word = word.Trim();
            }
            return word;
        }
    
        /// <summary>
        /// Does this word exist in this trie?
        /// </summary>
        public bool IsWordInTrie(string word)
        {
            word = NormaliseWord(word);
            if (String.IsNullOrWhiteSpace(word)) return false;
            var selectedNode = TopNode;
            foreach (var c in word)
            {
                if (!selectedNode.Nodes.ContainsKey(c)) return false;
                selectedNode = selectedNode.Nodes[c];
            }
            return selectedNode.Terminal;
        }
    }
