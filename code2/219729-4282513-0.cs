    public static class UnitOfWorkSS  
    {
        private static _unitOfWork;
        public static IUnitOfWork UnitOfWork
        {
            set { _unitOfWork = value; }
            private get{ _unitOfWork ?? (_unitOfWork = IoC.Resolve<IUnitOfWork>()); }
        }
        public static IUnitOfWork Begin()  
        {  
            return UnitOfWork;
        }  
    }  
    [TestMethod]
    public void DoStuff()
    {
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        UnitOfWorkSS.UnitOfWork = mockUnitOfWork.Object;
        //Do some setup and verify
    }
