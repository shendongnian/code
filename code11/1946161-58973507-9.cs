    private readonly IUnitOfWork<YourDbContext> _unitOfWork = null;
    private readonly IYourRepository _repository = null;
    
    public YourService(IUnitOfWork<YourDbContext> unitOfWork, IYourRepository repository)
    {
       _unitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
       _repository = repository ?? throw new ArgumentNullException("repository");
    }
