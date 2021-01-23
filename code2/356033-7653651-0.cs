      var IUnitOfWork _unitOfWork;
    
      public MyService(IUnitOfWork uow)
      {
        _unitOfWork = uow;
      }
    
      public void DoSomeOperation(SampleParam param)
      {
        _unitOfWork.BeginTrx();
        //  do some work 
        _unitOfWork.Commit();
      }
