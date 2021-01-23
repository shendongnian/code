    Dispatcher.BeginInvoke(() =>
    {
      StreamItems.Add(new StreamItemViewModel
      {
          Content = responseContent
      });
    }
