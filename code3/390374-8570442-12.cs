    void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        Update();
    }
    public void Update()
    {
        while (serialPortN.BytesToRead > 0)
            buffer.Add((byte)serialPortN.ReadByte());
        ProcessBuffer(buffer);
    }
