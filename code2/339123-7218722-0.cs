    public class UsesMyService
    {
        private readonly IMyService _service;
        public UsesMyService()
        {
            _service = SomeClassWithContainer.UnityContainer.Resolve<IMyService>();
        }
    }
