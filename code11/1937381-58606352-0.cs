    private readonly Stopwatch stopwatch = new Stopwatch();
    ...
    stopwatch.Start();
    private void QuizTimer_Tick(object sender, EventArgs e)
    {
        lblQuizTimer.Content = stopwatch.Elapsed.ToString(@"mm\:ss");
    }
