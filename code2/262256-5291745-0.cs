    public void SetText(FlowDocument document, string text)
    {
        Action action = () =>
        {
            TextRange tr = new TextRange(document.ContentStart,
                                                  document.ContentEnd);
            using (MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(text)))
            {
                tr.Load(ms, DataFormats.Rtf);
            }
        };
        Dispatcher.CurrentDispatcher.BeginInvoke(action,
                                                 DispatcherPriority.Background);
    }
