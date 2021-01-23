    public class MockViewModelLocator
    {
        public IUserServiceAsync UserService
        {
            get
            {
                return new MockUserService();
            }
        }
    }
