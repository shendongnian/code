    public class ViewModelLocator
    {
        IoCContainer Container { get; set; }
        public IUserServiceAsync UserService
        {
            get
            {
                return IoCContainer.Resolve<IUserServiceAsync>();
            }
        }
    }
