    int value = 0;
    while (true)
    {
        lock (m_Locker)
        {
            if (m_Queue.Count > 0)
            {
                value = m_Queue.Dequeue();
                break;
            }
        }
        m_AutoResetEvent.WaitOne();
    }
