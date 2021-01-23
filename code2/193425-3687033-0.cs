    public class SomePresenter
    {
        private readonly ISomeView _view;
        private readonly ISomeRepository _repository;
        public class SomePresenter(ISomeView view, ISomeRepository repository)
        {
            _view = view;
            _repository = repository;
        }
 
        public void Foo()
        {
            var model = _repository.GetModel();
            // TODO: work with the model and update the view
        }
    }
