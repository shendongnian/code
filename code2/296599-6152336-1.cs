    private void LoopingMethod()
    {
    for (int i = 0; i < 10; i++)
    {
      label1.Content = i.ToString();
      label1.Refresh();
      Thread.Sleep(500);
    }
    }
