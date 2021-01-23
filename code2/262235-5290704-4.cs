    public static void Main(string[] args)
    {
        check_news(); // You can add an argument 'false' to stop it from executing async
        Console.WriteLine("Done");
        Console.ReadKey();
    }
    public delegate void Func();
    public static void check_news(bool async = true)
    {
        Func checkNewsFunction = () =>
            {
                //Check news here
                Thread.Sleep(1000);
            };
        if (async)
        {
            AsyncCallback callbackFunction = ar =>
            {
                // Executed when the news is received
            };
            checkNewsFunction.BeginInvoke(callbackFunction, null);
        }
        else
            checkNewsFunction();
    }
