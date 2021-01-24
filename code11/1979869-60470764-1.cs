    [Fact]
        public void ManagerTest()
        {
            // arrange
            MockedUser mockedUser = new MockedUser();
            // act
            Manager manager = new Manager(mockedUser);
            // assert 
            Assert.Equal("Firstname", manager.GetUser().GetFirstName());
        }
    public class Manager
        {
            private IUser _user; 
    
            public Manager(IUser user)
            {
                _user = user;
            }
    
            public IUser GetUser()
            {
                return _user;
            }
        }
    public class MockedUser : IUser
        {
            public string GetFirstName()
            {
                return "Firstname";
            }
    
            public string GetFullName()
            {
                return "Firstname Middlename Lastname";
            }
    
            public string GetLastName()
            {
                return "Lastname";
            }
    
            public string GetMiddleNames()
            {
                return "Middlename";
            }
    
            public void SetFirstName(string firstname)
            {
                return;
            }
    
            public void SetFullName(List<string> fullName)
            {
                return;
            }
    
            public void SetLastName(string lastname)
            {
                return;
            }
    
            public void SetMiddleNames(List<string> middleNames)
            {
                return;
            }
        }
    public interface IUser : INames
        {
            void SetFirstName(string firstname);
    
            void SetLastName(string lastname);
    
            void SetMiddleNames(List<string> middleNames);
    
            void SetFullName(List<string> fullName);
    
            string GetFullName();
    
            string GetFirstName();
    
            string GetLastName();
    
            string GetMiddleNames();
        }
