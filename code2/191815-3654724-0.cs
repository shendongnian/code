    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.ServiceProcess;
    using System.Threading;
    
    namespace DotNetWarrior.ServiceProcess
    {  
      public class ServiceManager
      {
        private List<ServiceBase> _services = new List<ServiceBase>();
    
        public void RegisterService(ServiceBase service)
        {
          if (service == null) throw new ArgumentNullException("service");
          _services.Add(service);
        }
    
        public void Start(string[] args)
        {
          if (Environment.UserInteractive)
          {
            foreach (ServiceBase service in _services)
            {
              Start(service, args);
            }
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
            Thread.Sleep(Timeout.Infinite);
          }
          else
          {
            ServiceBase.Run(_services.ToArray());
          }
        }    
    
        public void Stop()
        {
          foreach (ServiceBase service in _services)
          {
            Stop(service);
          }
        }
    
        private void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
          Stop();
          Environment.Exit(0);
        }
    
        private void Start(ServiceBase service, string[] args)
        {
          try
          {
            Type serviceType = typeof(ServiceBase);       
            
            MethodInfo onStartMethod = serviceType.GetMethod(
              "OnStart", 
              BindingFlags.NonPublic | BindingFlags.Instance, 
              null, 
              new Type[] { typeof(string[]) }, 
              null);
    
            if (onStartMethod == null)
            {
              throw new Exception("Could not locate OnStart");
            }
    
            Console.WriteLine("Starting Service: {0}", service.ServiceName);
            onStartMethod.Invoke(service, new object[] { args });
            Console.WriteLine("Started Service: {0}", service.ServiceName);
          }
          catch (Exception ex)
          {
            Console.WriteLine("Start Service Failed: {0} - {1}", service.ServiceName, ex.Message);
          }
        }
    
        private void Stop(ServiceBase service)
        {
          try
          {
            Type serviceType = typeof(ServiceBase);
            MethodInfo onStopMethod = serviceType.GetMethod(
              "OnStop", 
              BindingFlags.NonPublic | BindingFlags.Instance);
            if (onStopMethod == null)
            {
              throw new Exception("Could not locate OnStart");
            }
            Console.WriteLine("Stoping Service: {0}", service.ServiceName);
            onStopMethod.Invoke(service, null);
            Console.WriteLine("Stopped Service: {0}", service.ServiceName);
          }
          catch (Exception ex)
          {
            Console.WriteLine("Stop Service Failed: {0} - {1}", service.ServiceName, ex.Message);
          }
        }
      }
    }
