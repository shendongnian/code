    public IAsyncResult BeginWriteLine2(string line1, string line2, AsyncCallback callback, object state)
    {
        Action action = new Action(() => m_LineWriter.WriteLine(line1, line2));
        return m_Asynchronizer.DoAction.BeginInvoke(action, callback, state);
    }
    public void EndWriteLine2(IAsyncResult result)
    {
        m_Asynchronizer.DoAction.EndInvoke(result);
    }
