        public MainPage()
        {
            this.InitializeComponent();
            DataContext = ViewModelDispatcher.DialerViewModel;
        }
        /// <summary>
        /// Processes press and hold for the buttons that supports press and hold. E.g
        /// 1 -> Voicemail
        /// 0 -> +
        /// * -> , (pause)
        /// # -> ; (wait)
        /// </summary>
        private void OnDialPadHolding(object sender, Windows.UI.Xaml.Input.HoldingRoutedEventArgs e)
        {
            Button button = (Button)sender;
            DialerViewModel vm = (DialerViewModel)DataContext;
            if ((vm != null) && (e.HoldingState == Windows.UI.Input.HoldingState.Started))
            {
                vm.ProcessDialPadHolding.Execute(button.Tag);
            }
        }
