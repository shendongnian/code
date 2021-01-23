    public delegate void MyEventHandler(string text);
    void IncomingEvent(string text)
    {
       if(!IsDisposed && InvokeRequired)
           Invoke(new MyEventHandler(IncomingEvent), text);
       else
           label.Text = text;
    }
