        static private void GenericDereferenceArray<T>(T t)
        {
            Console.WriteLine(string.Format("GenericDereferenceArray<T>(T t) got a {0} which thinks it's a {1}, {2}", typeof(T), t.GetType(), t));
            if (t is IEnumerable)
                foreach (var t2 in (IEnumerable)t)
                {
                    GenericDereferenceArray(t2);
                }
        }
