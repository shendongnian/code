    string exePath = Application.StartupPath 
    public Boolean IsRunningFromDesktop(){
      if(exePath.Contains(desktopPath)){
         return true;
       }
      return false;
    }
