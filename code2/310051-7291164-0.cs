    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
            {
                PhoneApplicationFrame RootFrame = Application.Current.RootVisual as PhoneApplicationFrame;
    
                if (RootFrame != null)
                {
                    if (RootFrame.BackStack.Count() > 0)
                    {
                        RootFrame.RemoveBackEntry();
                    }
                }
    
            }
