    public MainWindow Window
        {
            get;set;
        }
        private MainWindow _Window;
        public void AddNewTask()
        {
            var taskUC = new NewTaskUserControl();
            Window.tasksSP.Children.Add(taskUC);
        }
