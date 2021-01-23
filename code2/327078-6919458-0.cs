    private void UpdateMyUI(object myParam)
    {
         if (InvokeRequired)
         {
             // We're not in the UI thread, so we need to call BeginInvoke
             BeginInvoke(new MyDelegate(UpdateStatus), new object[]{value});
             return;
          }
          // Must be on the UI thread if we've got this far.
          // Do UI updates here.      
    }
