    ManualResetEvent _canReadEvent = new ManualResetEvent(true);
    
    public void WriterThreadFunc()
    {
        while (_canReadEvent.Wait() && reader.Read())
        {
            foreach(writer in writers)
            {
                writer.WriteToStream();
            }
        }
    }
    public void Pause()
    {
        _canReadEvent.Reset();
    }
    public void Continue()
    {
        _canReadEvent.Set();
    }
