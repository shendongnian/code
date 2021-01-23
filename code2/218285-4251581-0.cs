    class TaskTray : ApplicationContext
    {
        private NotifyIcon _Icon;
        public TaskTray()
        {
           _Icon = new NotifyIcon();
           //...
        )
    }
    static void Main()
    {
        Application.Run(new TaskTray());
    }
