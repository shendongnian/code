    public static async Task UseMethodWithAsyncVoid()
    {
        try
        {
            await MethodWithException();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ex Message" + e.Message);
        }
    }
    
    
