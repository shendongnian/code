    private void buttonStart_Click(object sender, EventArgs e)
    {
      // Starts a task that runs the operation (on background thread)
      // Note: I added 'ToList' so that the result is actually evaluated
      // and all results are stored in an in-memory data structure.
      var task = Task.Factory.StartNew(() =>
        Directory
            .EnumerateFiles(@"c:\temp", "*.txt", SearchOption.AllDirectories)
            .AsParallel()
            .WithCancellation(m_CancellationTokenSource.Token)
            .SelectMany(File.ReadLines)
            .SelectMany(ReadWords)
            .GroupBy(word => word, (word, words) => 
                new Tuple<int, string>(words.Count(), word))
            .OrderByDescending(occurrencesWordPair => occurrencesWordPair.Item1)
            .Take(20).ToList(), m_CancellationTokenSource.Token);
    
      // Specify what happens when the task completes
      // Use 'this.Invoke' to specify that the operation happens on GUI thread
      // (where you can safely access GUI elements of your WinForms app)
      task.ContinueWith(res => {
        this.Invoke(new Action(() => {
          try
          {
            foreach (Tuple<int, string> tuple in res.Result)
            {
              Console.WriteLine(tuple);
            }
          }
          catch (OperationCanceledException ex)
          {
              Console.WriteLine(ex.Message);
          }
        }));
      });
    }
