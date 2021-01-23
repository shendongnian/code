    private void MockUserPrincipal()
        {
            //Mock principal context
            var context = Mock.Create<PrincipalContext>((action) => action.MockConstructor());
            //Mock user principal
            var user = Mock.Create(() => new UserPrincipal(context));           
            
            //Mock the properties you need
            Mock.Arrange(() => user.Enabled).Returns(true);
            Mock.Arrange(() => user.UserPrincipalName).Returns("TestUser");
            Mock.Arrange(() => user.LastPasswordSet).Returns(DateTime.Now);
            //Mock any functions you need
            Mock.Arrange(() => user.IsAccountLockedOut()).Returns(false);
            //Setup static UserPrincipal class
            Mock.SetupStatic<UserPrincipal>();
            //Mock the static function you need
            Mock.Arrange(() => UserPrincipal.FindByIdentity(Arg.IsAny<PrincipalContext>(), Arg.AnyString)).Returns(user);  
            
            //Now calling UserPrincipal.FindByIdentity with any context and identity will return the mocked UserPrincipal
        }
