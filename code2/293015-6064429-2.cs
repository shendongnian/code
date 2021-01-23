        static void Main(string[] args)
        {
            var ugly = new ArrayList();
            ugly.Add("strings are evil");
            ugly.Add("yeah");
            ugly.Add(1);
            ugly.Add(3);
            ugly.Add(1234);
            ugly.WithType<int>(x => Console.WriteLine("im a lousy int! " + x))
                .AndType<string>(x => Console.WriteLine("and im dangerous string: " + x))
                .Execute();
            Console.ReadKey();
        }
        static TypedCollectionView WithType<T>(this IEnumerable x, Action<T> action)
        {
            return new TypedCollectionView(x).AndType(action);
        }
        class TypedCollectionView
        {
            private readonly IEnumerable collection;
            private readonly Dictionary<Type, Action<object>> actions = new Dictionary<Type, Action<object>>();
            public TypedCollectionView(IEnumerable collection)
            {
                this.collection = collection;
            }
            public TypedCollectionView AndType<T>(Action<T> action)
            {
                actions.Add(typeof(T), o => action((T)o));
                return this;
            }
            public void Execute()
            {
                foreach (var item in collection)
                {
                    var itemType = item.GetType();
                    foreach (var action in
                        from kv in actions
                        where kv.Key.IsAssignableFrom(itemType)
                        select kv.Value)
                    {
                        action(item);
                    }
                }
            }
        }
