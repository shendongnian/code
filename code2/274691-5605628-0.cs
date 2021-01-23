    class Kernel : ApplicationContext
    {
        private TaskbarIcon tb = new TaskbarIcon();
        public void Show()
        {
            var ballon = new Warning();
            tb.ShowCustomBalloon(balloon, PopupAnimation.Fade, 12000);
        }
        /// <summary>
        /// Closes the application.
        /// </summary>
        public void Close()
        {
            Application.Exit();
        }
    }
