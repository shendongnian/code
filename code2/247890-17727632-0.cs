    static PhoneApplicationFrame ApplicationRootFrame
    {
      get { return ((PhoneApplicationFrame) Application.Current.RootVisual); }
    }
    
    ApplicationRootFrame.OrientationChanged += OnOrientationChanged
