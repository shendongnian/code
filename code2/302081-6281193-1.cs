    public static T2[][] ToMultidimensionalArray<T, T2>(
                                                    this IEnumerable<T> enumerable,
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
                // Get the required property info using reflection
                var propertyInfo = typeof(T).GetProperty(prop);
                // Extract the getter method of the property
                var getter = propertyInfo.GetGetMethod();
                // Invoke the getter and get the property value
                var value = getter.Invoke(item, null);
                // Cast the value to T2 and store in the array
                resultArray[i][j] = (T2) value;
                j++;
            }
            i++;
        }
        return resultArray;
    }
