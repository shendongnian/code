      class MainWindowViewModel : ViewModelBase
      {
          private ICommand _showLogInWindowCommand;
          public ICommand ShowLogInWindowCommand
          {
             get
             {
                  if (_showLogInWindowCommand == null)
                  {
                      _showLogInWindowCommand = new DelegateCommand(OnLoaded)
                  }
                  return _showLogInWindowCommand;
             }
          }
          private void OnLoaded()
          {
              //// Put all your code here....
          }
      } 
