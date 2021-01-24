    public partial class uc_WorkingArea : UserControl
    {
        public CancellationTokenSource cts = new CancellationTokenSource();
        public CancellationToken token;
        public Task Printer1;
    
        public uc_WorkingArea()
        {
            token = cts.Token;
            Printer1 = Task.Factory.StartNew(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.WriteLine("run");
                    Application.DoEvents();
                }
            }, token);
        }
    }
