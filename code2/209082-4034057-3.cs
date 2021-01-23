    public class ViewModelLocator
    {
        IoCContainer Container { get; set; }
        public IUserViewModel UserViewModel
        {
            get
            {
                return IoCContainer.Resolve<IUserViewModel>();
            }
        }
    }
