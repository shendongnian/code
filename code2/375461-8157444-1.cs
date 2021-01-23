    public async void Form_Load(object sender, EventArgs args)
    {
      label1.Text = "Loading..."
      // Do some more stuff here if necessary.
      label1.Text = await Run();
    }
    
    private Task<string> Run()
    {
      var tcs = new TaskCompletionSource<string>();
      Task.Factory.StartNew(
        () =>
        {
          for (int i = 0; i < 1000000; i++)
          {
          }
          tcs.SetResult("Finished");
        });
        return tcs.Task;
    }
