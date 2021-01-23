    System.InvalidOperationException: The calling thread must be STA, because many UI components require this.
       at System.Windows.Input.InputManager..ctor()
       at System.Windows.Input.InputManager.GetCurrentInputManagerImpl()
       at System.Windows.Input.KeyboardNavigation..ctor()
       at System.Windows.FrameworkElement.FrameworkServices..ctor()
       at System.Windows.FrameworkElement.EnsureFrameworkServices()
       at System.Windows.FrameworkElement..ctor()
       at System.Windows.Controls.Control..ctor()
       at System.Windows.Window..ctor()
