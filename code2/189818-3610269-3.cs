    MyObject myObject = this.MyObject;
    Thread task = new Thread(()=>
        {
            Thread.Sleep(1000); // wait a second (for a specific reason)
            DoTheCodeThatNeedsToRunAsynchronously();
            myObject.ChangeSomeProperty();
        });
    task.IsBackground = true;
    task.Start();
    task.Join(); // blocks the main thread until the task thread is finished
    myObject = that.MyObject; // the assignment will happen after the task is complete
