    public IAsyncResult BeginWriteLine(string line, AsyncCallback callback, object state)
    {
        Action action = () => m_LineWriter.WriteLine(line);
        return m_Asynchronizer.DoAction.BeginInvoke(action, callback, state);
    }
    public void EndWriteLine(IAsyncResult result)
    {
        m_Asynchronizer.DoAction.EndInvoke(result);
    }
