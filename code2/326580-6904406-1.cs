    using Gma.UserActivityMonitor.GlobalEventProvider;
    
    GlobalEventProvider _globalEventProvider1 
                                     = new Gma.UserActivityMonitor.GlobalEventProvider();
     
    this.globalEventProvider1.MouseMove += HookMouseMove;//to listen to mouse move
 
