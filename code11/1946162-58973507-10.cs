    private readonly IUnitOfWork<YourDbContext> _unitOfWork = null;
    
    public YourService(IUnitOfWork<YourDbContext> unitOfWork)
    {
       _unitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
    }
    private YourDbContext Context { get { return _unitOfWork.Context; } }
