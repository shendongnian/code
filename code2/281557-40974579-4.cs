    public class TaskController
    {
        private readonly ITaskRepository _repository;
        private readonly ILogger _logger;
        public TaskController(ITaskRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public ITaskRepository Repository
        {
            get { return _repository; }
        }
        public ILogger Logger
        {
            get { return _logger; }
        }
    }
