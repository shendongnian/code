    private async void button1_Click(object sender, EventArgs e)
    {
      await Button1ClickAsync();
    }
    public async Task Button1ClickAsync()
    {
      // Do asynchronous work.
      await Task.Delay(1000);
    }
