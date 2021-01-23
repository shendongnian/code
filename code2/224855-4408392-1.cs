    private void StartService(string WinServiceName)
    {
        try
        {
            using(ServiceController sc = new ServiceController(WinServiceName,"."))
            {
                if (sc.ServiceName.Equals(WinServiceName))
                {
                    //check if service stopped
                    if (sc.Status.Equals(System.ServiceProcess.ServiceControllerStatus.Stopped))
                    {
                       sc.Start();
                    }
                    else if (sc.Status.Equals(System.ServiceProcess.ServiceControllerStatus.Paused))
                    {
                        sc.Continue();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            label3.Text = ex.ToString();
            MessageBox.Show("Could not start " + WinServiceName + "Service.\n Error : " + ex.ToString(), "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
