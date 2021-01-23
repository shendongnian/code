    public IObservable<IResponse> Process(IObservable<IRequest> requests)
    {
    	Func<IRequest, IObservable<IResponse>> rq2rp =
    		ObservableEx.FromAsyncCallbackPattern
    			<IRequest, IResponse>(requestProcessor.Process);
    
    	var query = (
    		from rq in requests
    		select rq2rp(rq)).Concat();
    			
    	var uow = unitOfWorkFactory.Create();
    	var subject = new ReplaySubject<IResponse>();
    	
    	query.Subscribe(
    		r => subject.OnNext(r),
    		ex =>
    		{
    			uow.Rollback();
    			subject.OnError(ex);
    		},
    		() =>
    		{
    			uow.Commit();
    			subject.OnCompleted();
    		});
    	
    	return subject.AsObservable();
    }
