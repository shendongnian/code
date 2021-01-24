    public class AppViewModel : ReactiveObject
    {
        private readonly ObservableAsPropertyHelper<IStatus> _status;
        public string Status => _status.Value;
        public MyClient Client { get; }
        public AppViewModel(MyClient client)
        {
            Client = client;
            Client.StatusStream().ToProperty(this, x => x.Status, out _status);
        }
    }
