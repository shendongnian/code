    private delegate void ControlCallback(string s);
    public void CallControlMethod(string text)
    {
        if (control.InvokeRequired)
        {
            ControlCallback call = new ControlCallback((s) =>
            {
                // do control stuff
            });
            control.Invoke(call, new object[] { text });
        }
        else
        {
            // do control stuff
        }
    }
