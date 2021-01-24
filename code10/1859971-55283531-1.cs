    class Program
    {
        static SynchronizationContext mainThreadContext;
        static void Main()
        {
            // app initialization code here
            // you could also do this somewhere in your main window
            mainThreadContext = SynchronizationContext.Current;
        }
        static void MessengerEvent(object sender, EventArgs<string> e)
        {
            // do additional stuff here that can be done on a background thread
 
            // The UpdateUI method will be executed on the UI thread
            mainThreadContext.Post(_ => UpdateUI(), null);
        }
        static void UpdateUI() { }          
    }
