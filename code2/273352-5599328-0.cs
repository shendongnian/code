    foreach (TraceListener listener in s.Listeners)
                    {
                       listener.Dispose();
                       Console.WriteLine("disposing");
                    }
