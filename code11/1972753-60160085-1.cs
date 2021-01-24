    public class Communicator : ReactiveObject
    {
        private bool _connected;
        public bool Connected
        {
            get { return _connected; }
            set { this.RaiseAndSetIfChanged( ref _connected, value); }
        }
    }
