    void ResetTimer()
    {
        sessionTimer.Stop();
        sessionTimer.Start();
    }
    private void port_DataRecieved(object sender, SerialDataReceivedEventArgs e)
    {
        //Other codes
        this.Invoke(ResetTimer);
        //Other codes
    }
