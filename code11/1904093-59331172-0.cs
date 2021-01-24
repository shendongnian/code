        public MainPage()
        {
            CoreWindow cw = CoreWindow.GetForCurrentThread();
            CoreDispatcher cd = cw.Dispatcher;
            cd.AcceleratorKeyActivated += Cd_AcceleratorKeyActivated;
            this.InitializeComponent();
        }
        private void Cd_AcceleratorKeyActivated(CoreDispatcher sender, AcceleratorKeyEventArgs args)
        {
            if (this.pwBox.FocusState != FocusState.Unfocused)
            {
                if(args.VirtualKey == Windows.System.VirtualKey.A)
                {
                    args.Handled = true;
                }
            }
        }
    }
