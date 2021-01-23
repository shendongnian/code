            foreach (Delegate handler in myDelegate.GetInvocationList())
            {
                try
                {
                    handler.Method.Invoke(handler.Target, null);
                }
                catch(Exception ex)
                {
                    // use ex
                }
            }
