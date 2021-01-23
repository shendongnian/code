    public static EventHandler MyEvent;
    
    [STAThread]
    static void Main()
    {
       MyEvent += (s,dea) => 1.ToString ();
       MyEvent -= null;
    
       Console.WriteLine (x.GetInvocationList ().Length);
       // Prints 1
    }
