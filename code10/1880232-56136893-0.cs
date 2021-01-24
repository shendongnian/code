    public static T[] GetZeroArrayIfNot<T>(this T[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException("array");
        }
        else if (array.Length == 0)
        {
            return array;
            // because the name of the method implies that a zero-length array
            // should be treated differently than a non-zero-length array
        }
        return new T[0];
    }
    public static int HundredOrLess(int num)
    {
        if (num <= 100)
        {
            return num;
            // It doesn't matter. The caller is not affected either way
            // because num is an immutable value type passed by value
        }
        return 100;
    }
    public static List<T> ReturnItself<T>(List<T> list)
    {
        return list; // Because the method name says so
    }
