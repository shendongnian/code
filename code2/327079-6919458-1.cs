    private void aMethod(object myParam)
    {
         if (InvokeRequired)
         {
             // We're not in the UI thread, so we need to call BeginInvoke
             BeginInvoke(new MyDelegate(aMethod), new object());
             return;
          }
          // Must be on the UI thread if we've got this far.
          // Do UI updates here.      
    }
