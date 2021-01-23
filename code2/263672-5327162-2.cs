    // assuming the the following code resides in a WPF control
    //  hence "this" is a reference to a WPF control which has a Dispatcher
    System.Threading.ThreadPool.QueueUserWorkItem((WaitCallback)delegate{
        // put long-running code here
        // get the result
        // now use the Dispatcher to invoke code back on the UI thread
        this.Dispatcher.Invoke(DispatcherPriority.Normal,
                 (Action)delegate(){
                      // this code would be scheduled to run on the UI
                 });
    });
