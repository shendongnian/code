    public ViewResult Index()
    {
        string username = User.Identity.NameWithoutDomain().ToUpper();
    
        var vm = new ReturnGoodsAuthorizationViewModel()
        {
            ReturnGoodsAuthorizations = _returnGoodsAuthorizationRepository.GetAll(),
            ReasonCodes = _reasonCodeRepository.GetAll(),
            RestockFeeOptions = _restockFeeOptionRepository.GetAll(),
            Customers = _customerRepository.GetAll(),
            RGA = new ReturnGoodsAuthorization()
            {
                PreparedByUser = username,
                AuthorizedByUser = username,
                CreateUser = username
            }
        };
        return View("Index", vm);
    }
