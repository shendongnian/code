    IsBusy = true;
    DomainContext.InvokeMyOperation(c=>
                                        {
                                          //in callback
                                          IsBusy = false;
                                        });
