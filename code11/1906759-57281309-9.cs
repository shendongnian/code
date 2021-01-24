     public ObservableCollection<TaskViewModel> TaskSource
        {
            get
            {
                return _TaskSource;
            }
            set
            {
                _TaskSource = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<TaskViewModel> _TaskSource=new ObservableCollection<TaskViewModel>();
        
        public void AddNewTask()
        {
            TaskSource.Add(new TaskViewModel() { Task = Task });
            //var taskUC = new NewTaskUserControl();
            //Window.tasksSP.Children.Add(taskUC);
        }
