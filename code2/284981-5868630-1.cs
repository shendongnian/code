            foreach (Delegate handler in myDelegate.GetInvocationList())
            {
                try
                {
                    object params = ...;
                    handler.Method.Invoke(handler.Target, params);
                }
                catch(Exception ex)
                {
                    // use ex
                }
            }
