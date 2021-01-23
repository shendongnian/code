    public class UsesMyService
    {
        private readonly IMyService _service;
        public UsesMyService(IMyService service)
        {
            _service = service;
        }
    }
