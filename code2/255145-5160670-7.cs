    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    
    namespace TagCloudDemo
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
    
                DataContext = new VM();
            }
        }
    
        public class VM
        {
            public VM()
            {
                Words = LoadWords();
                Tags = Tag.CreateTags(Words);
            }
    
            public IEnumerable<string> Words { get; private set; }
    
            public IEnumerable<Tag> Tags { get; private set; }
    
            private static IEnumerable<string> LoadWords()
            {
                Random random = new Random();
    
                string loremIpsum =
                    "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
                string[] tokens = loremIpsum.Split(new char[] {' '});
                List<string> words = new List<string>();
                for (int i = 0; i < 500; i++)
                {
                    words.Add(tokens[random.Next(tokens.Count())]);
                }
                return words;
            }
        }
        
        public class Tag
        {
            public Tag(string name, int weight)
            {
                Name = name;
                Weight = weight;
            }
    
            public string Name { get; set; }
            public int Weight { get; set; }
    
            public static IEnumerable<Tag> CreateTags(IEnumerable<string> words)
            {
                Dictionary<string, int> tags = new Dictionary<string, int>();
                foreach (string word in words)
                {
                    int count = 1;
                    if (tags.ContainsKey(word))
                    {
                        count = tags[word] + 1;
                    }
                    tags[word] = count;
                }
    
                return tags.Select(kvp => new Tag(kvp.Key, kvp.Value));
            }
        }
    }
