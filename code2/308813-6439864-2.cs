    public static event EventHandler MyEvent;
    
    [STAThread]
    static void Main()
    {
       MyEvent += (s,dea) => 1.ToString ();
       MyEvent -= null;
    
       Console.WriteLine (MyEvent.GetInvocationList ().Length);
       // Prints 1
       MyEvent = null;
       Console.WriteLine (MyEvent == null);
       // Prints true
    }
