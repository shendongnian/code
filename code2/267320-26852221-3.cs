    public RelayCommand ShowPopUpCommand
    {
       get
       {
       return _showPopUpCommand ??
          (_showPopUpCommand = new RelayCommand(
             () =>
                   {
                    // Put if statement here
                   }
          }));
       }
    }
