    using Microsoft.SqlServer.Management.Smo.Wmi;
    
    ManagedComputer mc = new ManagedComputer("localhost");
    foreach (Service svc in mc.Services) {
        if (svc.Name == "MSSQL$SQLEXPRESS"){
            textSTW.Text = svc.ServiceState.ToString();
        }
        if (svc.Name == "MSSQL$TESTSERVER"){
            textST1.Text = svc.ServiceState.ToString();
        }
        if (svc.Name == "MSSQL$TESTSERVER3") {
            textST2.Text = svc.ServiceState.ToString();
        }
    }
