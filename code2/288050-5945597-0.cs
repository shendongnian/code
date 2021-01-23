    class Program
    {
        [MTAThread]
        static void Main(string[] args)
        {
            RunAsSTAThread(
                () =>
                {
                    Clipboard.SetText("Hallo");
                    Console.WriteLine(Clipboard.GetText());
                });
        }
        /// <summary>
        /// Start an Action within an STA Thread
        /// </summary>
        /// <param name="goForIt"></param>
        static void RunAsSTAThread(Action goForIt)
        {
            AutoResetEvent @event = new AutoResetEvent(false);
            Thread thread = new Thread(
                () =>
                {
                    goForIt();
                    @event.Set();
                });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            @event.WaitOne();
        }
    }
