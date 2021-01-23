    private void InitControls()
    {
      var numControlsToBuild = SomeDatabaseCallToGetNumControls();
      int idCounter = 1;
      foreach(var controlData in numControlsToBuild)
      {
        var control = this.Page.LoadControl("MyControl.ascx") as MyUserControl;
        control.ID = "MyControl" + idCounter.ToString();
        idCounter++;
        UserControlPlaceHolder.Controls.Add(myControl);
        _MyUserControls.Add(control);
        // probably code load control data into control
      }
    }
