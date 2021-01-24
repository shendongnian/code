        public class MainVM : ViewModelBase
        {
            private ObservableCollection<EllipseVM> _Ellipses;
            public ObservableCollection<EllipseVM> Ellipses
            {
              get => _Ellipses;
              set => Set(ref _Ellipses, value);
            }
        }
