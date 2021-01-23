    ThreadPool.QueueUserWorkItem(Multiply, new object[] { 2, 3 }); 
    public static void Multiply(object state)
    {
        object[] array = state as object[];
        int x = Convert.ToInt32(array[0]);
        int y = Convert.ToInt32(array[1]);
    }
