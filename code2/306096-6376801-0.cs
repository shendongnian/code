    static void Main()
    {
        Func<string, int> method = Work;
        method.BeginInvoke ("test", Done, method);
       // ...
       //
    }
 
    static int Work (string s) { return s.Length; }
 
    static void Done (IAsyncResult cookie)
    {
        var target = (Func<string, int>) cookie.AsyncState;
        int result = target.EndInvoke (cookie);
        Console.WriteLine ("String length is: " + result);
    }
