    private static void Rotate<T>(T[] array, int rotateBy)
    {
        rotateBy %= array.Length;
        // Nothing to do?
        if (rotateBy == 0)
            return;
        // Normalize it to a right rotation
        if (rotateBy < 0)
            rotateBy = array.Length + rotateBy;
        // Allocate the smallest possible temp array
        if (rotateBy > array.Length / 2)
        {
            T[] temp = new T[array.Length - rotateBy];
            Array.Copy(array, 0, temp, 0, array.Length - rotateBy);
            Array.Copy(array, array.Length - rotateBy, array, 0, rotateBy);
            Array.Copy(temp, 0, array, rotateBy, array.Length - rotateBy);
        }
        else
        {
          	T[] temp = new T[rotateBy];
            Array.Copy(array, array.Length - rotateBy, temp, 0, rotateBy);
            Array.Copy(array, 0, array, rotateBy, array.Length - rotateBy);
            Array.Copy(temp, 0, array, 0, rotateBy);  
        }
    }
