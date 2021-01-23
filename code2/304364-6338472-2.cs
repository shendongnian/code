    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    public static bool ConstantCompare(byte[] array1, byte[] array2)
    {
        const byte Zero = 0;
        int maxLength = array1.Length > array2.Length ? array1.Length : array2.Length;
        bool wereEqual = array1.Length == array2.Length;
    
        byte[] paddedArray1 = new byte[maxLength];
        byte[] paddedArray2 = new byte[maxLength];
        for (int i = 0; i < maxLength; i++)
        {
            paddedArray1[i] = array1.Length > i ? array1[i] : Zero;
            paddedArray2[i] = array2.Length > i ? array2[i] : Zero;
        }
        bool compareResult = true;
        for (int i = 0; i < maxLength; i++)
        {
            compareResult = compareResult & paddedArray1[i] == paddedArray2[i];
        }
        return compareResult & wereEqual;
    }
