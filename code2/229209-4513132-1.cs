        private void RaiseEventAsync(Delegate handler, object e)
        {
            if (null != handler)
            {
                List<Delegate> invocationList = handler.GetInvocationList().ToList();
                foreach (Delegate singleCast in invocationList)
                {
                    System.ComponentModel.ISynchronizeInvoke syncInvoke =
                               singleCast.Target as System.ComponentModel.ISynchronizeInvoke;
                    try
                    {
                        if ((null != syncInvoke) && (syncInvoke.InvokeRequired))
                            syncInvoke.Invoke(singleCast,
                                          new object[] { this, e });
                        else
                            singleCast.Method.Invoke(singleCast.Target, new object[] { this, e });
                    }
                    catch
                    { }
                }
            }
        }
