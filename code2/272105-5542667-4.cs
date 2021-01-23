    private void MutexViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
       MutexViewModel m = (MutexViewModel)sender;
       if (e.PropertyName != "IsChecked" || !m.IsChecked)
       {
         return;
       }
       foreach (MutexViewModel other in _Mutexes.Where(x: x != m))
       {
          other.IsChecked = false;
       }
    }
