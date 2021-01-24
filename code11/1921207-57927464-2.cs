    [TestClass]
    public class HomeControllerTest
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<ICurrentUser> _currentUserMock;
        private HomeController _objController;
        [TestInitialize]
        public void Initialize()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _currentUserMock = new Mock<ICurrentUser>();
            _currentUserMock.Setup(x => x.GetUserDetails()).Returns(new User { Username = "TEST", Role = "ADMIN", LoggedIn = "Y" });
            _objController = new HomeController(_unitOfWorkMock.Object, _currentUserMock.Object);
        }
    }
