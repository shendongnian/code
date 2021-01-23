    public static T2[][] ToMultidimensionalArray<T, T2>(IEnumerable<T> enumerable,
                                                        int count,
                                                        params string[] propNames)
    {
        T2[][] resultArray = new T2[count][];
        int i = 0;
        int arrLength = propNames.Length;
        foreach (var item in enumerable)
        {
            resultArray[i] = new T2[arrLength];
            int j = 0;
            foreach (string prop in propNames)
            {
                var propertyInfo = typeof(T).GetProperty(prop);
                var getter = propertyInfo.GetGetMethod();
                var value = getter.Invoke(item, null);
                resultArray[i][j] = (T2) value;
                j++;
            }
            i++;
        }
        return resultArray;
    }
