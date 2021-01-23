    void AssignArrayToRange()
    {
        // Create & the array.
        object[,] myArray = new object[10, 10];
        // Initialize the array.
        for (int i = 0; i < myArray.GetLength(0); i++)
        {
            for (int j = 0; j < myArray.GetLength(1); j++)
            {
                myArray[i, j] = i + j;
            }
        }
        // Create a Range of the correct size:
        int rows = myArray.GetLength(0);
        int columns = myArray.GetLength(1);
        Excel.Range range = myWorksheet.get_Range("A1", Type.Missing);
        range = range.get_Resize(rows, columns);
        // Assign the Array to the Range in one shot:
        range.set_Value(Type.Missing, myArray);
    }
