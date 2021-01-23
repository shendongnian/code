    public class YourForm : Form
    {
      private volatile bool _pause = false;
      private void StartButton_Click(object sender, EventArgs e)
      {
        var thread = new Thread(
          () =>
          {
            while (...)
            {
              // Periodically poll the _pause flag.
              while (_pause)
              {
                // Now that we're paused, wait until we're unpaused
                // before proceeding further in the outer loop
                Thread.Sleep(100);
              }
              // Todo: The rest of the processing here
            }
          });
        thread.Start();
      }
    
      private void PauseButton_Click(object sender, EventArgs e)
      {
        _pause = !_pause; // Toggle
      }
    }
