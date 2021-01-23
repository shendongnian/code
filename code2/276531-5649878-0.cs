    public class MyTimerClass
    {
        private bool isParsing;
        // Other methods here which initiate the log file parsing.
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (!isParsing)
            {
                isParsing = true;
                ParseLogFiles();
                isParsing = false;
            }
        }
    }
