        [TestMethod]
        public async Task ActiveDirectoryUserFactory_CreateUserAsyncAndWhatYouExpect()
        {
            // Arrange
            using(ShimsContext.Create())
            {
                var userPrincipal = new System.DirectoryServices.AccountManagement.Fakes.ShimUserPrincipal();
                var baseUserPrincipal = new System.DirectoryServices.AccountManagement.Fakes.ShimAuthenticablePrincipal(userPrincipal);
                
                
                baseUserPrincipal.LastPasswordSetGet = () => DateTime.Now;
                
                // Mock the returned UserPrincipal to use our userPrincipal, here's for Moq
                _class.Setup(x => x.GetUserAsync("param"))
                    .Returns(Task.FromResult<UserPrincipal>(userPrincipal));
                // Act, your method that gets your shimUserPrincipal from _class.GetUserAsync in your _target class (I understood you got the UserPrincipal from external source)
                var user = await _target.YourMethod();
                
                // Assert
                Assert.IsNull(user);
            }
            
        }
        // method that does the code you want to test
        public async Task<Object> YourMethod()
        {
            var user = await _class.GetUserAsync("param");
            var lastLogin = user.LastPasswordSet;
            return new Object()
        }
