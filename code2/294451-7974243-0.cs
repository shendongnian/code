    public class CustomMembershipProvider : MembershipProvider
    {
		private IServiceFactory _serviceFactory;
	
        public CustomMembershipProvider() : this(null) { }
        public CustomMembershipProvider(IServiceFactory factory)
        {
            // IF no factory was provided, we need to get one from the bootstrapper
            if (factory == null)
                _serviceFactory = new WindsorServiceFactory(Bootstrapper.WindsorContainer);
            else
                _serviceFactory = factory;
        }
		
		public override string ResetPassword(string email, string answer)
        {
            var unitOfWork = GetUnitOfWork();
            return new ResetUserPasswordCommand(unitOfWork).WithUserEmail(email).Execute();
        }
		
		private IUnitOfWork GetUnitOfWork()
        {
           return _serviceFactory.GetService<IUnitOfWork>();
        }
	}
