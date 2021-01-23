            try
            {
                Exception exc;
                using (ManualResetEvent resetEvent = new ManualResetEvent(false))
                {
                  Thread ThreadB = new Thread(() =>
                  {
                    try
                    {
                        MyClass2.DoThat();
                    }
                    catch (Exception e)
                    {
                        exc = e;
                        resetEvent.Set();
                    }
                  });
                  ThreadB.Start();
                  if (resetEvent.WaitOne(10000))
                  {
                    throw exc;
                  }
                }
            }
            catch (Exception e)
            {
                // I want to know if something went wrong with MyClass2.DoThat
            }
