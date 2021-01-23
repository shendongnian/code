    public static class ArrayInitializer
    {
        public static T[] Init<T>(this T[] array) where T : new()
        {
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = new T();
            }
            return array;
        }
    }
    ...
    var valueHolders = new Holder[n].Init();
