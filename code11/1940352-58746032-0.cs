    public Shared.Task SelectedTask
    {
       get
       {
          return _selectedTask;
       }
       private set
       {
          _selectedTask = value;
          OnPropertyChanged(() => SelectedTask);
       }
    }
