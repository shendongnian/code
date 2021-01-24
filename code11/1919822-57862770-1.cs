	public class OfferService : IOfferService
	{
		private IUserServiceFactory _userServiceFactory;
		private ISomeOtherService _someotherService;
		public OfferService(IUserServiceFactory userServiceFactory, ISomeOtherService someotherService)
		{
			_userServiceFactory = userServiceFactory;
			_someotherService = someotherService;
		}
		public bool SomeMethod()
		{
			string key = _someotherService.GetKey();
			string val = _someotherService.GetValue();
			var user = _userServiceFactory.GetUserService(key, val);
			return false;
		}
	} 
