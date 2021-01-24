    public ViewResult Index()
    {
        var vm = new ReturnGoodsAuthorizationViewModel()
        {
            ReturnGoodsAuthorizations = _returnGoodsAuthorizationRepository.GetAll(),
            ReasonCodes = _reasonCodeRepository.GetAll(),
            RestockFeeOptions = _restockFeeOptionRepository.GetAll(),
            Customers = _customerRepository.GetAll(),
            RGA = new ReturnGoodsAuthorization()
            {
                PreparedByUser = User.Identity.NameWithoutDomain().ToUpper(),
                AuthorizedByUser = User.Identity.NameWithoutDomain().ToUpper(),
                CreateUser = User.Identity.NameWithoutDomain().ToUpper()
            }
        };
        return View("Index", vm);
    }
