    DispatcherOperation dispOp  = this.Dispatcher.BeginInvoke(balUpdater,
       GlobalParams._sessionObject.UserInfo.CardData);
    dispOp.Completed += (sender, args) => HandleCompletion(dispOp);
    ...
    private void HandleCompletion(DispatcherOperation operation)
    {
        object result = operation.Result;
        // Use the result here
    }
