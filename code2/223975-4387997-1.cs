    static private int[] toIntArray(string[] strArray)
    {
        int[] intArray = new int[strArray.Length];
        for (int index = 0; index < strArray.Length; index++)
        {
            if (Int32.Parse(strArray[index]) != null)
            {
                intArray[index] = Int32.Parse(strArray[index]);
            }
            else
            {
                intArray[index] = 0;
            }           
        }
        return intArray;
    }
  
