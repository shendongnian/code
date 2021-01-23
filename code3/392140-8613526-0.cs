        Dictionary<Type, Delegate> dictionary = new Dictionary<Type, Delegate>();
        public void Map<T>(Func<string, T> mapper)
        {
            dictionary[typeof(T)] = mapper;
        }
        public T Call<T>(string value)
        {
            var func = dictionary[typeof(T)] as Func<string, T>;
            return func.Invoke(value);
        }
