    Random random = new Random();
    Stopwatch stopwatch = new Stopwatch();
    List<long> timesTested = new List<long>();
    private void buttonStart_Click(object sender, EventArgs e) {     
      stopwatch.Reset();
      for (int i = 4; i > 0; --i) {
        btnReactionButton.Text = i.ToString();
        Task.Delay(500).Wait();
        btnReactionButton.Invalidate();
      }
      btnReactionButton.Text = "Press this button when it turns green";
      Task.Delay(random.Next(3000, 5000)).Wait();
      stopwatch.Start();
      btnReactionButton.BackColor = Color.Green;
      btnReactionButton.Text = "Click Now!";   
    }
    private void btnReactionButton_Click(object sender, EventArgs e) {
      if (stopwatch.IsRunning) {
        stopwatch.Stop();
        timesTested.Add(stopwatch.ElapsedMilliseconds);
        btnReactionButton.BackColor = Color.Red;
        btnReactionButton.Text = string.Format("Your time was {0} milliseconds",
                                               timesTested[timesTested.Count - 1]);
        if (timesTested.Count == 3) {
          MessageBox.Show("Your times were: " + String.Join(", ", timesTested.ToArray()));
        }
      }
    }
