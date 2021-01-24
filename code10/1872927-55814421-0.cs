    public class ViewModel : ReactiveObject
    {
        [Reactive]
        public bool DepthLabel { get; set; }
        public ViewModel()
        {
            Observable.Timer(TimeSpan.FromSeconds(2))
               .ObserveOnDispatcher()
               .Subscribe(_ => DepthLabel = true);
        }
    }
