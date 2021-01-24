    using System;
    using System.Collections.Generic;
    
    namespace SortedDictionrayTest
    {
    
        class AddingEventArgs<TKey, TValue> : EventArgs
        {
            public TKey Key
            {
                get;
            }
    
            public TValue Value
            {
                get;
            }
    
            public AddingEventArgs(TKey key, TValue value)
            {
                this.Key = key;
                this.Value = value;
            }
        }
    
        class AddedEventArgs<TKey, TValue> : AddingEventArgs<TKey, TValue>
        {
            public AddedEventArgs(TKey key, TValue value) : base(key, value)
            {
            }
        }
    
        class MySortedDictionay<TKey, TValue> : SortedDictionary<TKey, TValue>
        {
            public event EventHandler<AddingEventArgs<TKey, TValue>> Adding;
            public event EventHandler<AddedEventArgs<TKey, TValue>> Added;
    
            public new void Add(TKey key, TValue value)
            {
                this.OnAdding(new AddingEventArgs<TKey, TValue>(key, value));
                base.Add(key, value);
                this.OnAdded(new AddedEventArgs<TKey, TValue>(key, value));
            }
    
            protected virtual void OnAdding(AddingEventArgs<TKey, TValue> args)
            {
                if (this.Adding != null)
                {
                    Adding(this, args);
                }
            }
    
            protected virtual void OnAdded(AddedEventArgs<TKey,TValue> args)
            {
                if (this.Added != null)
                {
                    Added(this, args);
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var sortedDict = new MySortedDictionay<int, string>();
    
                sortedDict.Adding += SortedDict_Adding;
                sortedDict.Added += SortedDict_Added;
    
                sortedDict.Add(2, "World");
                sortedDict.Add(1, "Hello");
    
                Console.WriteLine("---");
                foreach (KeyValuePair<int, string> keyValuePair in sortedDict)
                {
                    Console.WriteLine($"key: [{keyValuePair.Key}] value: [{keyValuePair.Value}]");
                }
            }
    
            private static void SortedDict_Adding(object sender, AddingEventArgs<int, string> e)
            {
                Console.WriteLine($"before adding key: [{e.Key}] value: [{e.Value}]");
            }
    
            private static void SortedDict_Added(object sender, AddedEventArgs<int, string> e)
            {
                Console.WriteLine($"after adding key: [{e.Key}] value: [{e.Value}]");
            }
    
        }
    }
