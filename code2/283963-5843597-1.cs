       Action _webCallCompletedAction;
       public void InitializeConnexion(string name, Action action)
       {
           webCallCompletedAction = action;
           _ws.InitializeConnexionAsync(name);
       }
