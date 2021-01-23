    private object m_Lock = new object();
    private ManualResetEvent m_ResetOne = new ManualResetEvent(false);
    private ManualResetEvent m_ResetTwo = new ManualResetEvent(false);
    (...)
    new Thread(() => FirstMethod(tempList1)).Start();
    new Thread(() => SecondMethod(tempList2)).Start();
    m_ResetOne.WaitOne();
    m_ResetTwo.WaitOne();
    (...)
    private void FirstMethod(List<T> templist)
    {
        lock (m_Lock)
        {
            var temp = new T[templist.Count];
            templist.CopyTo(temp);
        }
        m_ResetOne .Set();
        //moves on
    }
    
    
