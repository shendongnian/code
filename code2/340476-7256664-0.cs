    ApplicationDeployment updateCheck = ApplicationDeployment.CurrentDeployment;
    UpdateCheckInfo info = updateCheck.CheckForDetailedUpdate();
    //
    if (info.UpdateAvailable)
    {
      updateCheck.Update();
      MessageBox.Show("The application has been upgraded, and will now restart.");
      Application.Restart();
    }
