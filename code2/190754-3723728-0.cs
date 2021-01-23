    public partial class App : Application
    {
        Window m_mainWindow;
        public App()
        {
            m_mainWindow = new Window { Left = int.MaxValue, Top = int.MaxValue, Width = 1, Height = 1 };
            m_mainWindow.ShowInTaskbar = false;
            
            // Comment this line out and the problem goes away
            m_mainWindow.Show();
        }
    }
