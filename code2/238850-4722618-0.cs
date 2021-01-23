    // input array
    T[] arr = Get();
    
    // find the item
    int index = Array.FindIndex(arr, i => i.ID == 1085);
    if (index == -1)
    	throw new InvalidOperationException();
    
    // get the item
    T item = arr[index];
    
    // place the item to the first position
    T[] result = new T[arr.Length];
    result[0] = item;
    
    // copy items before the index
    if (index > 0)
    	Array.Copy(arr, 0, result, 1, index);
    
    // copy items after the index
    if (index < arr.Length)
    	Array.Copy(arr, index + 1, result, index + 1, arr.Length - index - 1);
    return result;
