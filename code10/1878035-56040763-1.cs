    Console.WriteLine(((dynamic) svc).ServiceName);
    // Alternatively, use an explicit cast from .BaseObject:
    // Console.WriteLine(
    //   ((System.ServiceProcess.ServiceController) svc.BaseObject).ServiceName
    // );
