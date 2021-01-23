    public async void Form_Load(object sender, EventArgs args)
    {
      label1.Text = "Loading..."
      // Do some more stuff here if necessary.
      label1.Text = await Run();
    }
    
    private Task Run()
    {
      Task.StartNew(
        () =>
        {
          for (int i = 0; i < 1000000; i++)
          {
          }
        });
    }
