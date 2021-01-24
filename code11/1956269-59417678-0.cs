    {
        public class ViewModelBase: INotifyPropertyChanged
        {
            #region INotifyPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                var changed = PropertyChanged;
                if (changed == null)
                    return;
    
                changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
            protected bool SetProperty<T>(ref T backingStore, T value,
                [CallerMemberName]string propertyName = "",
                Action onChanged = null)
            {
                if (EqualityComparer<T>.Default.Equals(backingStore, value))
                    return false;
    
                backingStore = value;
                onChanged?.Invoke();
                OnPropertyChanged(propertyName);
                return true;
            }
        }
    }
