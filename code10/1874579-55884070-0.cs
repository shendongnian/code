    class Program
    {
        static void Main(string[] args)
        {
            var my_list = new List<int>() { 1, 2, 3 };
            var list2 = set_to_default<List<int>>(my_list);
            foreach (var elem in list2)
            {
                Console.WriteLine(elem);
            }
            Console.ReadKey();
        }
        public static T set_to_default<T>(T the_obj)
        {
            IEnumerable the_enumerable = the_obj as IEnumerable;
            if (the_enumerable != null)
            {
                Type type = the_enumerable.GetType().GetGenericArguments()[0];
                Type listType = typeof(List<>).MakeGenericType(new[] { type });
                IList list = (IList)Activator.CreateInstance(listType);
                var looper = the_enumerable.GetEnumerator();
                
                while (looper.MoveNext())
                {
                    var current_obj = looper.Current;
                    current_obj = Activator.CreateInstance(current_obj.GetType());
                    list.Add(current_obj);
                    
                }
                return (T)list;
            }
            else
            {
                return default(T);
            }
        }
    }
