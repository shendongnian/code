    var startTime = DateTime.Now;
    Test1D(new byte[1000 * 1000 * 3]);
    Console.WriteLine("Total Time taken 1d = " + (DateTime.Now - startTime));
    
    startTime = DateTime.Now;
    Test3D(new byte[1000,1000,3], 1000, 1000);
    Console.WriteLine("Total Time taken 3D = " + (DateTime.Now - startTime));
    
    public static void Test1D(byte[] array)
    {
        for (int c = 0; c < 2500; c++)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 10;
            }
        }
    }
    
    public static void Test3D(byte[,,] array, int w, int h)
    {
        for (int c = 0; c < 2500; c++)
        {
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    array[i, j, 0] = 10;
                    array[i, j, 1] = 10;
                    array[i, j, 2] = 10;
                }
             }
         }
    }
           
  
