    MyObject myObject = this.MyObject;
    ...
    timer.AutoReset = false; // i.e. only run the timer once.
    var localMyObject = myObject; // copy for lambda
    timer.Elapsed += new System.Timers.ElapsedEventHandler(
      delegate(object sender, System.Timers.ElapsedEventArgs e)
      {
        DoTheCodeThatNeedsToRunAsynchronously();
        localMyObject.ChangeSomeProperty();
      });
    // Now myObject can change without affecting timer.Elapsed
