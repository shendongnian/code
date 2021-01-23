    private void btnDemo_Click(object sender, RoutedEventArgs e)
    {
      Task tsk = Task.Factory.StartNew(() =>
      {
        for (int i = 0; i < 3; i++)
        {
          Dispatcher.BeginInvoke(new Action(() => {
             MyControl sprite = new MyControl();
             pnlTest.Children.Add(sprite);
          }));
        }
      });
    }
