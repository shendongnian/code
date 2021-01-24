    ServiceController sc = new ServiceController();
    sc.ServiceName = "AutomationServices";
    sc.MachineName = Dts.Variables["User::Server"].Value.ToString();
    if (sc.Status != null)
            {
            Dts.Variables["User::ServiceStatus"].Value = sc.Status.ToString();
            }
