    private void updateReceived(string s)
    {
        if (rtfReceiveWindow.InvokeRequired)
        {
            rtfReceiveWindow.Invoke(new Action(() => updateReceived(s); }));
        }
        rtfReceiveWindow.Text += s;
    }
    private void receiveData()
    {
        while (listening)
        {
            int recv = stream.ReadByte();
            if (recv != -1)
            {
                updateReceived(recv.ToString());
            }
        }
    }
