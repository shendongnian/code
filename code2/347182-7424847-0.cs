    public class DetailViewModel : IDisposable
    {
        private readonly CompositeDisposable _disposables
            = new CompositeDisposable();
        public void Dispose()
        {
            _disposables.Dispose();
        }
        private readonly MyDetailModel _model;
        public DetailViewModel(MyDetailModel model)
        {
            _model = model;
            _model.PropertyChanged += _model_PropertyChanged;
            Action removeHandler = () =>
                _model.PropertyChanged -= _model_PropertyChanged;
            _disposables.Add(removeHandler);
        }
        private void _model_PropertyChanged(
            object sender, PropertyChangedEventArgs e)
        { /* ... */ }
    }
