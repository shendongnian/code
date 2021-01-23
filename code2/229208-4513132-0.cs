    protected virtual void OnEvent(EventArgs e)
    {
        EventHandler handler = Event;
        if (null != handler)
        {
            foreach (EventHandler singleCast in handler.GetInvocationList())
            {
                ISynchronizeInvoke syncInvoke =
                            singleCast.Target as ISynchronizeInvoke;
                try
                {
                    if ((null != syncInvoke) && (syncInvoke.InvokeRequired))
                        syncInvoke.Invoke(singleCast,
                                        new object[] { this, e });
                    else
                        singleCast(this, e);
                }
                catch
                { }
            }
        }
    }
