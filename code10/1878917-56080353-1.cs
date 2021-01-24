    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    internal class Program
    {
        /// <summary>
        /// Derives from a Dictionary that is not sorted
        /// </summary>
        [DebuggerTypeProxy(typeof(DictDebugView))]
        public class MyDictionary : Dictionary<string, int>
        {
            /// <summary>
            /// Prepares unsorted dummy data
            /// </summary>
            public void PopulateDemoData()
            {
                foreach (char t in "GERZWIQSFHIWE")
                   this[new string(t, t / 10)] = t;
            }
            /// <summary>
            /// Is used as proxy for display
            /// </summary>
            internal class DictDebugView
            {
                private readonly SortedDictionary<string, int> sorted;
                public DictDebugView(Dictionary<string, int> data)
                    => sorted = new SortedDictionary<string, int>(data);
            
                /// <summary>
                /// Create the displayed KeyValuePairs
                /// </summary>
                [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
                public IList<KeyValuePair<string,int>> Keys
                {
                    get => sorted.Select(kvp => kvp).ToList();
                }
            }
        } 
    
        public static MyDictionary MyProp { get; } = new MyDictionary();
    
        public static void Main(string[] args)
        {
            var md = new MyDictionary();
            md.PopulateDemoData();
            var k = new Dictionary<string,int>(md); 
    
            Console.ReadLine();
        } 
    }
