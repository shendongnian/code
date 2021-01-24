    public static class Extension
    {
        public static T[][] ConcatArrays<T>(this T[][] array, T[][] concatWith)
        {
            var max = Math.Max(array.Length, concatWith.Length);
            var result = new T[max][];
            for (var index = 0; index < max; index++)
            {
                var list = new List<T>();
                if (index < array.Length)
                {
                    list.AddRange(array[index]);                   
                }
                if (index < concatWith.Length)
                {
                    list.AddRange(concatWith[index]);
                }
                result[index] = list.ToArray();
            }
            return result;
        }
    }
