    ManualResetEvent done = new ManualResetEvent(false);
    MyObject myObject = this.MyObject;
    Thread task = new Thread(()=>
        {
            Thread.Sleep(1000); // wait a second (for a specific reason)
            DoTheCodeThatNeedsToRunAsynchronously();
            myObject.ChangeSomeProperty();
            done.Set();
        });
    task.IsBackground = true;
    task.Start();
    done.WaitOne(); // blocks the main thread until the task thread signals it's done
    myObject = that.MyObject; // the assignment will happen after the task is done
