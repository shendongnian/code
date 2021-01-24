c#
class WinSocketServer:IDisposable
{
    public ManualResetEvent allDone = new ManualResetEvent(false);
    private CancellationTokenSource cancelSource = new CancellationTokenSource();
    private void _StartListening(CancellationToken cancelToken)
    {
        try
        {
            allDone.Reset(); // reset once before starting the loop
            while (true)
            {
                if (cancelToken.IsCancellationRequested)
                    break;
                Console.WriteLine("Waiting for a connection...");
                listener.BeginAccept(new AsyncCallback(AcceptCallback),listener);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        allDone.Set(); // notify that the listener is exiting
        Console.WriteLine("Complete");
    }
    public void StartListening()
    {
        Task.Run(() => _StartListening(cancelSource.Token));
    }
    public void StopListening()
    {
        // notify the listener it should exit
        cancelSource.Cancel(); 
        // wait until the listener notifies that it's actually exiting
        allDone.WaitOne();     
    }
    public void Dispose()
    {
        StopListening();
        cancelSource.Dispose();
        allDone.Dispose();
    }
}
