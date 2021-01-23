    private Mock<IUnitOfWork> _mockUnitOfWork;
    [TestInitialize]
    public void Init()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        
        //Making a lot of assumptions about your IoC here...
        IoC.Register<IUnitOfWork>(_mockUnitOfWork.Object);
    }
    [TestMethod]
    public void DoStuff()
    {
        _mockUnitOfWork.Setup( ... );
        //Do some verification
    }
