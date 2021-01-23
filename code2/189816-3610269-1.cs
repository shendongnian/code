    MyObject myObject = this.MyObject;
    Thread t = new Thread(()=>
        {
            Thread.Sleep(1000); // wait a second (for a specific reason)
            DoTheCodeThatNeedsToRunAsynchronously();
            myObject.ChangeSomeProperty();
        });
    t.IsBackground = true;
    t.Start();
