    int temp = 0;
    // Convert input string to an integer array by splitting on the space character and
    // using int.TryParse to convert the entry to an integer.
    // Also, since arrays are zero-based, we subtract 1 from the input value.
    // Finally, we only select integers that are valid indexes in our file array.
    int[] indexesToDelete = bye
        .Split(' ')
        .Where(item => int.TryParse(item, out temp) && temp > 0 && temp <= fiArr.Length)
        .Select(x => temp - 1)
        .ToArray(); 
    // For each index, call 'Delete' on that object
    foreach(int index in indexesToDelete)
    {
        fiArr[index].Delete();
    }
