        public MyControlElement()
        {
            this.DefaultStyleKey = typeof(MyControlElement);
            this.Loaded += MyControlElement_Loaded;
        }
        private void MyControlElement_Loaded(object sender, RoutedEventArgs e)
        {
            //
            //SOME INITIALIZE CODE HERE IF NEEDED
            //
            //RUN CONTROL VISUAL UPDATER ONLY IF IN DESIGN MODE
            if (DesignMode.DesignModeEnabled) ControlDesignTimeUIUpdater();
            //FLAG - CONTROL HAS BEEN INITIALIZED
            IsControlInitialized = true;
        }
