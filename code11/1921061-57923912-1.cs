    public static string[,] CombineArrayFunction(string[,] array1, string[,] array2)
    {
        if (array1.GetLength(1) != array2.GetLength(1))
        {
            throw new NotSupportedException("Arrays have to be the same size");
        }
    
        string[,] finalArray = new string[array1.GetLength(0) + array2.GetLength(0), array1.GetLength(1)];
    
        Array.Copy(array1, 0, finalArray, 0, array1.Length);
        Array.Copy(array2, 0, finalArray, array1.Length, array2.Length);
    
        return finalArray;
    }
