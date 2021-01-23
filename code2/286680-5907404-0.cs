    delegate void CallBackTest();
    CallBackTest callBackTest = new CallBackTest(TestCallBack);
    callBackTest.BeginInvoke(task, new AsyncCallback(functionExecuted), null);
    void TestCallBack()
    { }
    private void functionExecuted(IAsyncResult result)
    {
        try
        {
            callBackTest.EndInvoke(result);
        }
        catch (Exception ex)
        {
            //FileWriter.LogException(ex);
        }
    }
