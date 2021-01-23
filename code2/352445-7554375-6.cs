    public static class ArrayInitializer
    {
        public static T[] Init<T>(this T[] array)
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
