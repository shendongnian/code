    public class ShellViewModel: Screen
    {
        private string _title = "Some title";
        private Conductor<IScreen> _listConductor;
        private Conductor<IScreen> _detailConductor;
        public ShellViewModel()
        {
            _listConductor = new Conductor<IScreen>();
            _detailConductor = new Conductor<IScreen>();
            ListFrame = GetContainer().Resolve<ProductListViewModel>();
            DetailFrame = GetContainer().Resolve<ProductViewModel>();
        }
        public string Title { get => _title; set => _title = value; }
        public IScreen ListFrame
        {
            get { return _listConductor.ActiveItem; }
            set {
                _listConductor.ActivateItem(value);
                NotifyOfPropertyChange(nameof(ListFrame));
            }
        }
        public IScreen DetailFrame
        {
            get { return _detailConductor.ActiveItem; }
            set {
                _detailConductor.ActivateItem(value);
                NotifyOfPropertyChange(nameof(DetailFrame));
            }
        }
