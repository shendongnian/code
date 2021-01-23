     Mock<IRepository<>> repository;
        private Mock<ISmsService> smsService;
        const string phone = "0768524440";
        [SetUp]
        public void SetUp()
        {
               repository = new Mock<IRepository<>>();
             smsService = new Mock<ISmsService>();
        }
        [Test]
        public void WhenRegistreringANewUser_TheNewUserIsSavedToTheDatabase()
        {
            var userRegistration = new UserRegistrationProcess(repository.Object, smsService.Object);
            userRegistration.Register(phone);
            repository.VerifyAll();
            smsService.VerifyAll();
        }
