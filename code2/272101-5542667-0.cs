    public MutexesViewModel(IEnumerable<MutexViewModel> mutexes)
    {
       _Mutexes = new ObservableCollection<MutexViewModel>();
       foreach (MutexViewModel m in Mutexes)
       {
          _Mutexes.Add(m);
          m.PropertyChanged += MutexViewModel_PropertyChanged;
       }
    }
