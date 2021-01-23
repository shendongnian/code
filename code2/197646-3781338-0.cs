    public class Library : IDisposable
    {
        private CallbackInvoker m_CallbackInvoker;
    
        public Library(Action callback)
        {
            m_CallbackInvoker = new CallbackInvoker(callback);
        }
    
        public void Dispose()
        {
            m_CallbackInvoker.FinishAndWait();
        }
    
        private void DoSomethingThatInvokesCallback()
        {
            m_CallbackInvoker.Invoke();
        }
    
        private class CallbackInvoker
        {
            private Action m_Callback;
            private CountdownEvent m_Pending = new CountdownEvent(1);
    
            public CallbackInvoker(Action callback)
            {
                m_Callback = callback;
            }
    
            public bool Invoke()
            {
                if (m_Pending.TryAddCount())
                {
                    try
                    {
                        if (m_Callback != null)
                        {
                          m_Callback();
                        }
                    }
                    finally
                    {
                        m_Pending.Signal();
                    }
                    return true;
                }
                return false;
            }
    
            public void FinishAndWait()
            {
                m_Pending.Signal();
                m_Pending.Wait();
            }
    
        }
    }
