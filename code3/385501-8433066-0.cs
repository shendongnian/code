    int max = 0;
    string name = string.Empty;
    
    for (int index = 0; index < files.Length; index++)
    {
        int size = files[index].Length;
        //check if this file is the biggest we've seen so far
        if (size > max)
        {
            max = size; //store the size
            name = files[index].Name; //store the name
        }
    }
    
    //here, "name" will be the largest file name, and "max" will be the largest file size.
