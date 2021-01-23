    public class TasksViewModel : ObservableCollection<Task>
    {
        public int Completed
        {
            get { return this.Count(t => t.IsComplete); }
        }
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if(e.PropertyName == "Count") NotifyCompletedChanged();
        }
        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
            NotifyCompletedChanged();
        }
        void NotifyCompletedChanged()
        {
            OnPropertyChanged(_completedChangedArgs);
        }
        readonly PropertyChangedEventArgs _completedChangedArgs = new PropertyChangedEventArgs("Completed");
    }
