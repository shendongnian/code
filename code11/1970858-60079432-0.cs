    private static void QuestionTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        Console.WriteLine("Time up!");
        questionTimer.Stop();
    }
