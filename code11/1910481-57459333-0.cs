    public MainPage()
            {​
                this.InitializeComponent();​
                Window.Current.Dispatcher.AcceleratorKeyActivated += AccelertorKeyActivedHandle;​
            }
    
    private void AccelertorKeyActivedHandle(CoreDispatcher sender, AcceleratorKeyEventArgs args)
            {​
                if (args.EventType.ToString().Contains("Down"))​
                { ​
                        if (args.VirtualKey == Windows.System.VirtualKey.F3)​
                        {​
                            // do something you want
    ​
                        }​
                }​
            }
