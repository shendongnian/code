    for (int i = 1; i <= s.Length; i++)
    {
        string partialText = s.Substring(0, i);
        Dispatcher.DelayInvoke(TimeSpan.FromMilliseconds(500*i),
                                new Action(() =>
                                {
                                    textBlock1.Text = partialText;
                                }));
    }
