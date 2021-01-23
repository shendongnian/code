    public IAsyncResult BeginInsertWorkOrder(Dictionary<String, String> workOrderData, AsyncCallback callBack, Object state)
    {
        Action<Dictionary<String, String>> command = new Action<Dictionary<String, String>>(InsertWorkOrder);
        return command.BeginInvoke(workOrderData, callBack, command);
    }
