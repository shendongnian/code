      public RelayCommand<Project> StartTimer { get; private set; }//declare command
       StartTimer = new RelayCommand<Project>(OnStartTimer);
        private void OnStartTimer(Project project)
        {
            if (project != null)
            {
                currentProject = project;
                if (!timer.IsTimerStopped)
                {
                    timer.StopTimer();
                }
                else
                {
                    Caption = "Stop";
                    timer.StartTimer();
                }
            }
