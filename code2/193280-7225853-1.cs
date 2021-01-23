    ///<summary>
    ///  public RelayCommand<CancelEventArgs> WindowClosingCommand
    ///</summary>
    public RelayCommand<CancelEventArgs> WindowClosingCommand { get; private set; }
     ...
     ...
     ...
            // Window Closing
            WindowClosingCommand = new RelayCommand<CancelEventArgs>((args) =>
                                                                          {
                                                                              ShutdownService.MainWindowClosing(args);
                                                                          },
                                                                          (args) => CanShutdown);
