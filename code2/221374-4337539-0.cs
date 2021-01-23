    SomeClass.SomeEvent += SomeEventHandler;
    ...
    ...
    ...
    void SomeEventHandler()
    {
        // I'm assuming this code is in a class derived from Form
        this.BeginInvoke(new MethodInvoker(HandleEventOnUIThread));
    }
    
    void HandlerEventOnUIThread()
    {
        if (CheckToSeeIfFormIsAlreadyShowing())
        {
            SomeForm someForm = new SomeForm();
            someForm.ShowDialog();
        }
        else
        {
            DoSomeStuff();
        }
    }
