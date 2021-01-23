    public bool Validate()
    {  
       return  CheckInPath() &CheckOutPath()&CheckProcessedPath();
    }
    
      public bool CheckInPath()
      {
           if(!CheckPathExists(_settingsView.InPath)) {
                _settingsView.SetInPathError(directoryErrorMessage);
                 return false;
            }
            return true;
        }
            
         public bool CheckOutPath(string path)
         {
             if(!CheckPathExists(_settingsView.InPath)) {
                   _settingsView.SetOutPathError(directoryErrorMessage);
                   return false;
              }
              return true;
         }
            
          public bool CheckProcessedPath(string path)
          {
              if(!CheckPathExists(_settingsView.ProcessedPath)) {
                  _settingsView.SetProcessedPathError(directoryErrorMessage);
                   return false;
                }
                return true;
           }
