    public class MockViewModelLocator
    {
        public IUserViewModel UserViewModel
        {
            get
            {
                return new MockUserViewModel();
            }
        }
    }
