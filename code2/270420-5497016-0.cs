    public IObservable<bool> DoAsyncRequest()
    {
        return Observable.CreateWithDisposable<bool>(observer =>
            {    
                var disposable = this.api.Messages
                    .Where(m => m.RequestId == requestId)
                    .Take(1)
                    .Timeout(DefaultTimeout);
                    .Subscribe(observer);
    
                int requestId = GenerateRequestId();
    
                this.api.DoApiRequest(requestId);
    
                return disposable;
    
            });
    }
