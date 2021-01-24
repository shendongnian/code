    class Controller
    {
        private CarModelRepository _repository;
        public Controller()
        {
            _repository = new CarModelRepository();
        }
        public void DoSomething()
        {
            //use repository here
        }
    }
