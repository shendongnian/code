    Console.WriteLine(((dynamic) svc).ServiceName);
    // Alternatively, use an explicit cast from .BaseObject:
    // Console.WriteLine(
    //   ((System.ServiceProcess.ServiceController) s.BaseObject).ServiceName
    // );
