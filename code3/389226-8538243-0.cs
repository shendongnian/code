    void OnTick()
    {
        if (InvokeRequired)
            Invoke(new MethodInvoker(OnTick));
        else
        {
            Dispose();
        }
    }
