    public class YourForm : Form
    {
      private volatile bool _pause = false;
      private static ManualResetEvent mre = new ManualResetEvent(true);
      private void StartButton_Click(object sender, EventArgs e)
      {
        var thread = new Thread(ThreadImplementation);
        thread.Start();
      }
    
      private void PauseButton_Click(object sender, EventArgs e)
      {
        _pause = !_pause;
        if(_pause)
        {
          mre.Reset();
        }
        else
        {
          mre.Set();
        }
      }
      private void ThreadImplementation()
      {
        while (...)
        {
          // Periodically wait on the event
          mre.WaitOne();
          // Todo: The rest of the processing here
        }
      }
    }
