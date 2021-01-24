        public static object GetEmptyEnumerableOfType(this Type type)
        {
            var listOfModelType = typeof(List<>).MakeGenericType(type);
            var instance = Activator.CreateInstance(listOfModelType);
            return instance;
        }
