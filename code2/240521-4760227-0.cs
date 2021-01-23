    // Your passed in array.
    object[] objs = new object[5] {1,2,3,4,5};
    
    // Create an array of the same type.
    Array a = Array.CreateInstance(objs[0].GetType(), objs.Length+3);
    // Copy in values.
    objs.CopyTo(a,0);
