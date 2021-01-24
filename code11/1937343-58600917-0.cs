    private void OnModeChanged(string mode)
        {
            if (Application.Current.Dispatcher != null)
            {
                Application.Current.Dispatcher.BeginInvoke(
                    DispatcherPriority.Background,
                    new Action(
                        () =>
                        {
                            switch (mode)
                            {
                                default:
                                case "Game":
                                    _regionManager.RequestNavigate("GameRegion", "AnyGame");
                                    break;
                                case "Lockup":
                                    _regionManager.RequestNavigate("GameRegion", "LockupControl");
                                    break;
                                case "Menu":
                                    _regionManager.RequestNavigate("GameRegion", "MenuControl");
                                    break;
                            }
                        }));
            }
        }
