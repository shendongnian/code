    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace Example
    {
        public class Trie<T>
        {
            private struct Suffix
            {
                string text;
                int index;
    
                public Suffix(string theText)
                {
                    text = theText;
                    index = 0;
                }
    
                public bool IsEmpty()
                {
                    return index >= text.Length;
                }
    
                public char GetFirstChar()
                {
                    return text[index];
                }
    
                public Suffix GetNextSuffix()
                {
                    Suffix nextSuffix;
                    nextSuffix.text = text;
                    nextSuffix.index = index + 1;
    
                    return nextSuffix;
                }
            }
    
            private class TrieNode
            {
                public void Add(Suffix key, T value)
                {
                    if (key.IsEmpty())
                    {
                        values.Add(value);
                    }
                    else
                    {
                        int branchIndex = GetBranchIndexFromChar(key.GetFirstChar());
                        TrieNode node = branches[branchIndex];
    
                        if (node == null)
                            node = branches[branchIndex] = new TrieNode();
    
                        node.Add(key.GetNextSuffix(), value);
                    }
                }
    
                public TrieNode FindNode(Suffix key)
                {
                    if (key.IsEmpty())
                    {
                        return this;
                    }
                    else
                    {
                        int branchIndex = GetBranchIndexFromChar(key.GetFirstChar());
                        TrieNode node = branches[branchIndex];
    
                        if (node != null)
                            return node.FindNode(key.GetNextSuffix());
                        else
                            return null;
                    }
                }
    
                public IEnumerator<T> GetEnumerator()
                {
                    foreach (T value in values)
                        yield return value;
    
                    foreach (TrieNode node in branches)
                    {
                        if (node != null)
                        {
                            foreach (T value in node)
                                yield return value;
                        }
                    }
                }
    
                private static int GetBranchIndexFromChar(char ch)
                {
                    int index = -1;
    
                    if (char.IsNumber(ch))
                    {
                        index = ch - '0';
                    }
                    else
                    {
                        if (char.IsLower(ch))
                        {
                            index = NumDigits + (ch - 'a');
                        }
                        else if (char.IsUpper(ch))
                        {
                            index = NumDigits + NumLetters + (ch - 'A');
                        }
                    }
    
                    return index;
                }
    
                private static char GetCharFromBranchIndex(int index)
                {
                    char ch = '\0';
    
                    if (index >= 0)
                    {
                        if (index < NumDigits)
                            ch = (char)('0' + index);
                        else if (index < NumDigits + NumLetters)
                            ch = (char)('a' + (index - NumDigits));
                        else if (index < NumDigits + NumLetters + NumLetters)
                            ch = (char)('A' + (index - NumDigits - NumLetters));
                    }
    
                    return ch;
                }
    
                public IEnumerable<string> Keys
                {
                    get
                    {
                        if (values.Count > 0)
                            yield return "";
    
                        for (int branchIndex = 0; branchIndex < branches.Length; branchIndex++)
                        {
                            TrieNode node = branches[branchIndex];
                            if (node != null)
                            {
                                char branchChar = GetCharFromBranchIndex(branchIndex);
                                string keyPrefix = branchChar.ToString();
    
                                foreach (string key in node.Keys)
                                    yield return keyPrefix + key;
                            }
                        }
                    }
                }
    
                private static int NumDigits = 10;
                private static int NumLetters = 26;
    
                public List<T> values = new List<T>();
                private TrieNode[] branches = new TrieNode[NumDigits + NumLetters + NumLetters];
            }
    
            public void Add(string key, T value)
            {
                root.Add(new Suffix(key), value);
            }
    
            public IEnumerable<T> Find(string key)
            {
                TrieNode node = root.FindNode(new Suffix(key));
                if (node != null)
                {
                    foreach (T value in node.values)
                        yield return value;
                }
            }
    
            public IEnumerable<T> PrefixFind(string keyPrefix)
            {
                TrieNode node = root.FindNode(new Suffix(keyPrefix));
                if (node != null)
                {
                    foreach (T value in node)
                        yield return value;
                }
            }
    
            public IEnumerator<T> GetEnumerator()
            {
                return root.GetEnumerator();
            }
    
            public IEnumerable<string> Keys
            {
                get { return root.Keys; }
            }
    
            private TrieNode root = new TrieNode();
        }
    
        public class Program
        {
            static void Main(string[] args)
            {
                Trie<int> trie = new Trie<int>();
    
                trie.Add("a", 1);
                trie.Add("ab", 2);
                trie.Add("abc", 3);
    
                foreach (int i in trie.PrefixFind("ab"))
                    Console.WriteLine(i);
    
                foreach (string key in trie.Keys)
                    Console.WriteLine(key);
            }
        }
    }
