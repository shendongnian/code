    public delegate void MyEventHandler(string text);
    void IncomingEvent(string text)
    {
      if(IsDisposed)
        return;
      if(InvokeRequired)
        Invoke(new MyEventHandler(IncomingEvent), text);
      else
        label.Text = text;
    }
