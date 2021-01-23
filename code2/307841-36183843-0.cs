    using System;
    using System.Collections.Generic;
    using System.IO;
    
    namespace Resin
    {
        public class UseTrie
        {
            public void Main()
            {
                var words = new[]{"pre", "prefix"};
                var trie = new Trie(words);
    
                // Print "pre" and "prefix"
                foreach(var word in trie.GetTokens("pr"))
                {
                    Console.WriteLine(word);
                }
            }
        }
        public class Trie
        {
            public char Value { get; set; }
    
            public bool Eow { get; set; }
    
            public IDictionary<char, Trie> Children { get; set; }
    
            public bool Root { get; set; }
    
            public Trie(bool isRoot)
            {
                Root = isRoot;
                Children = new Dictionary<char, Trie>();
            }
    
            public Trie(IList<string> words)
            {
                if (words == null) throw new ArgumentNullException("words");
    
                Root = true;
                Children = new Dictionary<char, Trie>();
    
                foreach (var word in words)
                {
                    AppendToDescendants(word);
                }
            }
    
            public Trie(string text)
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    throw new ArgumentException("text");
                }
    
                Value = text[0];
    
                Children = new Dictionary<char, Trie>();
    
                if (text.Length > 1)
                {
                    var overflow = text.Substring(1);
                    if (overflow.Length > 0)
                    {
                        AppendToDescendants(overflow);
                    }
                }
                else
                {
                    Eow = true;
                }
            }
    
            public IEnumerable<string> GetTokens(string prefix)
            {
                var words = new List<string>();
                Trie child;
                if (Children.TryGetValue(prefix[0], out child))
                {
                    child.Scan(prefix, prefix, ref words);
                }
                return words;
            }
    
            private void Scan(string originalPrefix, string prefix, ref List<string> words)
            {
                if (string.IsNullOrWhiteSpace(prefix)) throw new ArgumentException("prefix");
    
                if (prefix.Length == 1 && prefix[0] == Value)
                {
                    // The scan has reached its destination. Find words derived from this node.
                    if (Eow) words.Add(originalPrefix);
                    foreach (var node in Children.Values)
                    {
                        node.Scan(originalPrefix+node.Value, new string(new []{node.Value}), ref words);
                    }
                }
                else if (prefix[0] == Value)
                {
                    Trie child;
                    if (Children.TryGetValue(prefix[1], out child))
                    {
                        child.Scan(originalPrefix, prefix.Substring(1), ref words);
                    }
                }
            }
    
            public void AppendToDescendants(string text)
            {
                if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("text");
    
                Trie child;
                if (!Children.TryGetValue(text[0], out child))
                {
                    child = new Trie(text);
                    Children.Add(text[0], child);
                }
                else
                {
                    child.Append(text);
                }
            }
    
            public void Append(string text)
            {
                if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("text");
                if (text[0] != Value) throw new ArgumentOutOfRangeException("text");
                if (Root) throw new InvalidOperationException("When appending from the root, use AppendToDescendants.");
    
                var overflow = text.Substring(1);
                if (overflow.Length > 0)
                {
                    AppendToDescendants(overflow);
                }
            }
        }
    }
