        public static void DoWork<T>() where T: new()
        {
            T t = new T();
            Console.WriteLine(t.ToString());
        }
