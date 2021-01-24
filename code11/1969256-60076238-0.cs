    public static void Test1<T>(object obj)
    {
        //How to get the values from object. I want to retrieve 2,3 and 4,5.
        if (obj is IEnumerable<T>)
        {
            // Vulgar display of power
            foreach (var stuff in new List<T>((IEnumerable<T>)obj))
            {
                Console.WriteLine("Stuff from the grave : {0}", stuff);
            }
        }
        else if (obj is T)
        {
            // My god... so wrong way
        }
    }
