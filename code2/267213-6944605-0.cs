    public static class ReflectiveEnumerator
    {
        static ReflectiveEnumerator() { }
    
        public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class, IComparable<T>
        {
            List<T> objects = new List<T>();
            foreach (Type type in Assembly.GetAssembly(typeof(T)).GetTypes())
            {
                if (type.IsClass && type.IsSubclassOf(typeof(T)) && !type.IsAbstract)
                {
                    objects.Add((T)Activator.CreateInstance(type, constructorArgs));
                }
            }
            objects.Sort();
            return objects;
        }
    }
