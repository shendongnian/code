    public class NotifyObservableCollection<T> : ObservableCollection<T> where T : INotifyPropertyChanged
    {
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null) {
                foreach (object t in e.NewItems) {
                    PropertyChangedEventHandler handler =
                        (sender, args) => OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
                    ((T) t).PropertyChanged += handler;
                }
            }
            if (e.OldItems != null) {
                foreach (object t in e.OldItems) {
                    PropertyChangedEventHandler handler =
                        (sender, args) => OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
                    ((T) t).PropertyChanged -= handler;
                }
            }
            base.OnCollectionChanged(e);
        }
    }
