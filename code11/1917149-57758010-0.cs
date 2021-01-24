    public class Module1ViewModel : Screen, IHandle<ParentToChildEvent>
    {
        private IEventAggregator _events;
        public Module1ViewModel(IEventAggregator events)
        {
            _events = events;
            events.Subscribe(this);
        }
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                _events.PublishOnUIThread(new ChildToParentEvent(FirstName));
            }
        }
        public void Handle(string message)
        {
            FirstName = message;
        }
    }
