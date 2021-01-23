    [TestClass]
	public class JustMockTest
	{
		public interface IServiceBus
		{
			T Query<T>() where T : IRequest;
		}
		public interface IRequest
		{
		}
		public interface IRequestFor<TParameters, TResult> : IRequest
		{
			TResult With(TParameters parameters);
		}
		public class ValidateMember : IRequestFor<IValidateMemberParameters, bool>
		{
			public bool With(IValidateMemberParameters model)
			{
				return false;
			}
		}
		public class MembershipController
		{
			private IServiceBus _service;
			public MembershipController(IServiceBus service)
			{
				_service = service;
			}
			public bool Login(Login model)
			{
				return _service.Query<ValidateMember>().With(model);
			}
		}
		public interface IValidateMemberParameters
		{
		}
		public class Login : IValidateMemberParameters
		{
			public string Email;
			public string	Password;
			public bool RememberMe;
		}
		[TestMethod]
		public void Login_Post_ReturnsRedirectOnSuccess()
		{
			// Inject
			var service = Mock.Create<IServiceBus>();
			// Arrange
			var controller = new MembershipController(service);
			// Model
			var model = new Login
			{
				Email = "acceptible@email.com",
				Password = "acceptiblePassword",
				RememberMe = true
			};
			var validateMemberMock = Mock.Create<ValidateMember>();
			Mock.Arrange(() => service.Query<ValidateMember>())
						.Returns(validateMemberMock);
			Mock.Arrange(() => validateMemberMock.With(model)).IgnoreArguments()
						.Returns(true); 
			// Act
			var result = controller.Login(model);
			// Assert
			Assert.IsTrue(result);
		}
	}
