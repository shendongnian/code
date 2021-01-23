    //Check if service is running
    ServiceController mysqlServiceController = new ServiceController();
    mysqlServiceController.ServiceName = "MySql";
    var timeout = 3000;
    
    //Check if the service is started
    if (mysqlServiceController.Status == System.ServiceProcess.ServiceControllerStatus.Stopped
                    || mysqlServiceController.Status == System.ServiceProcess.ServiceControllerStatus.Paused)
    {
          mysqlServiceController.Start();
    
          try
          {
               //Wait till the service runs mysql
               ServiceController.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running, new TimeSpan(0, timeout, 0));
          }
          catch (System.ServiceProcess.TimeoutException)
          {
              //MessageBox.Show(string.Format("Starting the service \"{0}\" has reached to a timeout of ({1}) minutes, please check the service.", mysqlServiceController.ServiceName, timeout));
          }
    }
