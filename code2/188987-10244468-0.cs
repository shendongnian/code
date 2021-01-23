        public static bool IsTrue ;
        public App()
        {
            Startup += AppStartup;
        }
        public void DoWork()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Trace.WriteLine("blah");
            }
            IsTrue = false;
            
        }
        void AppStartup(object sender, StartupEventArgs e)
        {
            IsTrue = true;
            new Thread(DoWork).Start();
            while (IsTrue)
            { }
            Current.Shutdown();
        }
    }
}
