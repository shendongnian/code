    class NoNavFrame : Frame
    {
        public NoNavFrame()
        {
            this.Navigated += new System.Windows.Navigation.NavigatedEventHandler(NoNavFrame_Navigated);
        }
        void NoNavFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            this.NavigationService.RemoveBackEntry();
        }
    }
