        [TestMethod]
        public void ActivateUser_UserNotFound_ThrowsException()
        {
            var userRepositoryMock = GetUserRepositoryMock(mockSelectOne:false);
            // override one of the public UserRepository members to return a specific value.
            Isolate.WhenCalled(() => userRepositoryMock.SelectOne(null)).DoInstead(context =>
            {
                return null;
            });
            // call ActivateUser implementation.
            RegistrationServices.ActivateUser("foo@bar.com", "password", "activation-code");
        }
