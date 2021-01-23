    public class YourService : ServiceBase
    {
      private ManualResetEvent m_Stop = new ManualResetEvent(false);
    
      protected override void OnStart(string[] args)
      {
        new Thread(Run).Start();
      }
    
      protected override void OnStop()
      {
        m_Stop.Set();
      }
    
      private void Run()
      {
        while (!m_Stop.WaitOne(TimeSpan.FromSeconds(30))
        {
          MessageQueue.ProcessMessage();
        }
      }
    }
