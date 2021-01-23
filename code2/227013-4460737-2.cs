    try
    {
        if(!this.IsDisposed) 
        {
            this.BeginInvoke(new MethodInvoker(() =>
                                     
                          {
                                    // update my control
                          }
              ));
        }
    }
    catch ( InvalidOperationException )
    {
        // Do something meaningful if you need to.
    }
