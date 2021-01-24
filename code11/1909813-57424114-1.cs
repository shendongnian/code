    public static async Task Go() {
       // Create a CancellationTokenSource that cancels itself after # milliseconds
       var cts = new CancellationTokenSource(5000); // To cancel sooner, call cts.Cancel()
       var ct = cts.Token;
       try {
        // I used Task.Delay for testing; replace this with another method that returns a Task
         await Task.Delay(10000).WithCancellation(ct);
         Console.WriteLine("Task completed");
       }
       catch (OperationCanceledException) {
        Console.WriteLine("Task cancelled");
      }
    }
