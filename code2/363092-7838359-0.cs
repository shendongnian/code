    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Smo.Wmi;
    using Microsoft.SqlServer.Management.Common;
    static class SQLStart
    {
	    public static void StartSQLService()
	    {
		    //Declare and create an instance of the ManagedComputer object that represents the WMI Provider services.
		    ManagedComputer mc = default(ManagedComputer);
		    mc = new ManagedComputer();
		    //Iterate through each service registered with the WMI Provider.
		    Service svc = default(Service);
		    foreach ( svc in mc.Services) {
			    Console.WriteLine(svc.Name);
		    }
		    //Reference the Microsoft SQL Server service.
		    svc = mc.Services("MSSQLSERVER");
		    //Stop the service if it is running and report on the status continuously until it has stopped.
		    if (svc.ServiceState == ServiceState.Running) {
			    svc.Stop();
			    Console.WriteLine(string.Format("{0} service state is {1}", svc.Name, svc.ServiceState));
			    while (!(string.Format("{0}", svc.ServiceState) == "Stopped")) {
				    Console.WriteLine(string.Format("{0}", svc.ServiceState));
				    svc.Refresh();
			    }
			    Console.WriteLine(string.Format("{0} service state is {1}", svc.Name, svc.ServiceState));
			    //Start the service and report on the status continuously until it has started.
			    svc.Start();
			    while (!(string.Format("{0}", svc.ServiceState) == "Running")) {
				    Console.WriteLine(string.Format("{0}", svc.ServiceState));
				    svc.Refresh();
			    }
			    Console.WriteLine(string.Format("{0} service state is {1}", svc.Name, svc.ServiceState));
		    } else {
			    Console.WriteLine("SQL Server service is not running.");
		    }
	    }
    }
