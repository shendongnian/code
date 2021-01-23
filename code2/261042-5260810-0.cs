    using System.ServiceProcess;
    var controller = new ServiceController("LanmanServer");
    
    Console.WriteLine(controller.ServiceName); // <- this is the unique name
    Console.WriteLine(controller.DisplayName); // <- this is subject to change
