    private void OnTimer(object sender, ElapsedEventArgs e)
    {
      try{
        batchPollingTimer.Enabled = false;
        // ...
      } finally {
        batchPollingTimer.Enabled = true;
      }
    }
}
