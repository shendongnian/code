    private void btnStart_Click(object sender, EventArgs e)
    {
      CreateBackgroundColorSetter(Color.Aqua);
      CreateBackgroundColorSetter(Color.Black);
      CreateBackgroundColorSetter(Color.DarkKhaki);
      CreateBackgroundColorSetter(Color.Green);
    }
    private void CreateBackgroundColorSetter(Color color)
    {
      var thread = new Thread(() =>
                                {
                                  while (true)
                                  {
                                    theLabel = color;
                                    Thread.Sleep(100);
                                  }
                                });
      thread.IsBackground = true;
      thread.Start();
    }
