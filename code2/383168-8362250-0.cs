    public void StartAction()
    {
      var inProgress = HttpContext.Current.Session["actionInProgress"] as bool;
      if (!inProgress)
      {
         try
         {
            HttpContext.Current.Session["actionInProgress"] = true;
            MySqlController.DoWork();
         }
         finally
         {
            HttpContext.Current.Session["actionInProgress"] = false;
         }
      }
    }
