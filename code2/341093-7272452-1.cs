        class Program
        {
            static void Main(string[] args)
            {
                MainCollection<int, string, DateTime> collection = new MainCollection<int, string, DateTime>();
    
                collection.Add(Tuple<int, string>.Create(1, "Bob"), new DateTime(1992, 12, 1));
                collection.Add(Tuple<int, string>.Create(2, "James"), new DateTime(1945, 9, 1));
                collection.Add(Tuple<int, string>.Create(3, "Julie"), new DateTime(1976, 7, 15));
    
                DateTime date;
    
                date = collection.GetValue(1);
                Console.WriteLine("Bob birthdate: {0}", date);
    
                date = collection.GetValue("Julie");
                Console.WriteLine("#3 birthdate: {0}", date);
    
                Console.ReadLine();
            }
        }
    
        public class MainCollection<TKey1, TKey2, TValue>
        {
            Tuple<TKey1, TKey2> key;
            Dictionary<Tuple<TKey1, TKey2>, TValue> mainCollection = new Dictionary<Tuple<TKey1, TKey2>, TValue>();
    
            public void Add(Tuple<TKey1, TKey2> Key, TValue Value)
            {
                mainCollection.Add(Key, Value);
            }
    
            public TValue GetValue(TKey1 Key)
            {
                return mainCollection.Where(k => k.Key.Item1.Equals(Key))
                                     .Select(v => v.Value)
                                     .FirstOrDefault();
            }
    
            public TValue GetValue(TKey2 Key)
            {
                return mainCollection.Where(k => k.Key.Item2.Equals(Key))
                                     .Select(v => v.Value)
                                     .FirstOrDefault();
            }
    
        }
    
        public class Tuple<T1, T2>
        {
            readonly T1 item1;
            readonly T2 item2;
    
            Tuple(T1 item1, T2 item2)
            {
                this.item1 = item1;
                this.item2 = item2;
            }
    
            public static Tuple<T1, T2> Create(T1 Item1, T2 Item2)
            {
                return new Tuple<T1, T2>(Item1, Item2);
            }
    
            public T1 Item1
            { get { return item1; } }
    
            public T2 Item2
            { get { return item2; } }
        }
    }
