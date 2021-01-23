        #region Fields
           RelayCommand closeCommand;
          #endregion
    
      #region CloseCommand
    /// <summary>
    /// Returns the command that, when invoked, attempts
    /// to remove this workspace from the user interface.
    /// </summary>
    public ICommand CloseCommand
    {
        get
        {
            if (closeCommand == null)
                closeCommand = new RelayCommand(param => this.OnRequestClose());
            return closeCommand;
        }
    }
    #endregion // CloseCommand
    #region RequestClose [event]
    /// <summary>
    /// Raised when this workspace should be removed from the UI.
    /// </summary>
    public event EventHandler RequestClose;
    /// <summary>
    /// If requested to close and a RequestClose delegate has been set then call it.
    /// </summary>
    void OnRequestClose()
    {
        EventHandler handler = this.RequestClose;
        if (handler != null)
        {
            handler(this, EventArgs.Empty);
        }
    }
    #endregion // RequestClose [event]
 
