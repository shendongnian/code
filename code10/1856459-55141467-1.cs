    class Controller
    {
        private ICarModelRepository _repository;
        public Controller(ICarModelRepository repository)
        {
            _repository = repository;
        }
        public void DoSomething()
        {
            //use repository here
        }
    }
