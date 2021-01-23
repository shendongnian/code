    public static string Fun1 ()
    {
        Semaphore sem = new Semaphore(1,1);
        string stringToReturn = String.Empty;
        Func2(); //Func2 will after few sec fire event bellow 
        example.MyEvent += (object sender, WebBrowserDocumentCompletedEventArgs e) =>
                               {
                                   stringToReturn = "example"; //this wont be hardcoded
                                   sem.Release();
                               };
        sem.WaitOne();
        //wait for event to be handled and then return value
        return stringToReturn;
    }
    
