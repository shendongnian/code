    public static int[] ConvertStringToArray()
    {
        string str = "ABCA";
        char[] array;
        array = str.ToCharArray(0, str.Count());
        int[] into2ndarray = new int[] { };
        Dictionary<char, int> keySizes = new Dictionary<char, int> {
             { 'A', 2 },
             { 'B', 2 },
             { 'C', 2 }
        };
        int arraySize;
        foreach (char c in array)
        {
            if (keySizes.TryGetValue(c, out arraySize))
            {
                into2ndarray = new int[arraySize];
                break;
            }   
        }
        return into2ndarray;
    }
