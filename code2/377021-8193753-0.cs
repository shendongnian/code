    public MyForm() {
            Text = "Synchronization Context Task Scheduler Demo";
            Visible = true; Width = 400; Height = 100;
            m_syncContextTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }
