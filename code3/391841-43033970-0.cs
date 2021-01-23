    public class SilentObservableCollection<T> : ObservableCollection<T>
    {
        public void AddRange(IEnumerable<T> enumerable)
        {
            CheckReentrancy();
            int startIndex = Count;
            foreach (var item in enumerable)
                Items.Add(item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new List<T>(enumerable), startIndex));
            OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
        }
    }
