    public MainWindow()
    {
        this.CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, OnCloseWindow));
        this.CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, OnMaximizeWindow, OnCanResizeWindow));
        this.CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, OnMinimizeWindow, OnCanMinimizeWindow));
        this.CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, OnRestoreWindow, OnCanResizeWindow));
    
    }
    private void OnCanMinimizeWindow(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = this.ResizeMode != ResizeMode.NoResize;
    }
    
    private void OnCanResizeWindow(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = this.ResizeMode == ResizeMode.CanResize || this.ResizeMode == ResizeMode.CanResizeWithGrip;
    }
    
    private void OnCloseWindow(object sender, ExecutedRoutedEventArgs e)
    {
        Microsoft.Windows.Shell.SystemCommands.CloseWindow(this);
    }
    
    private void OnMaximizeWindow(object sender, ExecutedRoutedEventArgs e)
    {
        Microsoft.Windows.Shell.SystemCommands.MaximizeWindow(this);
    }
    
    private void OnMinimizeWindow(object sender, ExecutedRoutedEventArgs e)
    {
        Microsoft.Windows.Shell.SystemCommands.MinimizeWindow(this);
    }
    
    private void OnRestoreWindow(object sender, ExecutedRoutedEventArgs e)
    {
        Microsoft.Windows.Shell.SystemCommands.RestoreWindow(this);
    }
