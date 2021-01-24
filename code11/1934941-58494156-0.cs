    public static IList SumValues(int value, int times) // you need to define the type for the return list
    {
        List<object> sums = new List<object>(); // you could probably use List<int> here instead of object, unless there's some logic outside of this function that treats them as objects
        int incrementedValue = 0;
        for (int i = 0; i < times; i++) // i++ is the same as i = i+1, but a little cleaner
        {
            sums.Add(incrementedValue);
            incrementedValue += value;
        }
    
        return sums;
    }
