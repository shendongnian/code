        [Test, Isolated]
        public void ActivateUser_UserNotFound_ThrowsException()
        {
            var userRepositoryMock = Isolate.Fake.Instance<UserRepository>();
            Isolate.Swap.AllInstances<UserRepository>().With(userRepositoryMock);
            Isolate.WhenCalled(() => userRepositoryMock.SelectOne(null)).WillReturn(null);
            // call ActivateUser implementation.
            RegistrationServices.ActivateUser("foo@bar.com", "password", "activation-code");
            Isolate.Verify.WasNotCalled(() => userRepositoryMock.Save(null));
            Isolate.Verify.WasNotCalled(() => userRepositoryMock.Remove(null));
        }
