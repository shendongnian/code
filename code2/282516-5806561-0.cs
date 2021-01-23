    int[] intArray = new int[1000];
    fixed (int* ptr = intArray)
    {
        // assuming we want to work with elements [200,299]
        ptr += 200;
        // we're passing a pointer to the 200th element to the method, and telling it to work on the next 100 elements...
        DoSomethingWithSegment(ptr, 100);
    }
    private unsafe void DoSomethingWithSegment(int* ptr, int count)
    {
        for (int i = 0; i < count; i++)
        {
            // do something with ptr...
            ptr++;
        }
    }
