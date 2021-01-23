    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            var tasks = new ObservableCollectionWithSubscribers<Task>();
            tasks.SubscribeToChanges(Notify, "Completed");
            Tasks = tasks;
        }
        public ObservableCollection<Task> Tasks { get; private set; }
        public int Completed
        {
            get { return Tasks.Count(t => t.IsComplete); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string property)
        {
            var handler = PropertyChanged;
            if(handler != null) handler(this, new PropertyChangedEventArgs(property));
        }
    }
