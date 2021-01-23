        timerFilterEntering.Interval = 1000;
        timerFilterEntering.Tick += (sender, e) =>
            {
                timerFilterEntering.Enabled = false;
                GuessTheUserFinished(myTextBox.Text);
            }
        myTextBox.TextChanged += (sender, e) =>
            {
                timerFilterEntering.Enabled = false;
                timerFilterEntering.Enabled = true;
            }
    void GuesTheUserFinished(string inputSoFar)
    {
        // ToDo: Whatever you like to do with the input.
    }
