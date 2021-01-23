    static void Main(string[] args)
    {
        int[] arr = new int[10];
        for (int i = 0; i < arr.Length; i++)
            arr[i] = i;
    
        // arr = 0,1,2,3,4,5,6,7,8,9
    
        var segment = new ArraySegmentWrapper<int>(arr, 2, 7);
        segment[0] = -1;
        segment[6] = -1;
        // now arr = 0,1,-1,3,4,5,6,7,-1,9
        // this prints: -1,3,4,5,6,7,-1
        foreach (var el in segment)
            Console.WriteLine(el);
    }
