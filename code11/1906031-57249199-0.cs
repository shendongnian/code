    public static void work()
    {
        Thread.Sleep(3000);
        Console.WriteLine("TimeoutException");
        throw new TimeoutException();
    }
    public static void Main(string[] args)
    {
        Thread thread = new Thread(() => SafeExecute(() => work(), Handler));
        thread.Start();
        Console.WriteLine("Result : ~~~");
        Console.ReadLine();
    }
    private static void Handler(Exception exception)
    {
        Console.WriteLine(exception);
    }
    private static void SafeExecute(Action test, Action<Exception> handler)
    {
        try
        {
            test.Invoke();
        }
        catch (TimeoutException ex)
        {
            Console.WriteLine("It's too long. Timeout!");
        }
        catch (Exception ex)
        {
            Handler(ex);
        }
    }
