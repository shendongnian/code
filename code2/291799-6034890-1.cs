    public void UpdateTextBoxCallback(string data)
    {
        if (uiTextBoxLiveLogView.InvokeRequired)
        {
            uiTextBoxLiveLogView.Invoke(new DifferentClassLibrary.StringDataDelegate(UpdateTextBoxCallback), data);
        }
        else
        {
            uiTextBoxLiveLogView.Text += data;
        }
    }
    void Main()
    {
        DifferentClassLibrary test = new DifferentClassLibrary();
        test.UpdatedData += UpdateTextBoxCallback;
        Thread thread = new Thread(new ThreadStart(test.DoStuff));
        thread.Start();
    }
