    // Loader and Container for MarshalByRefObject in another domain
     public class PluginFile : IDisposable
     {
               private RemotingSponsor _sponsor; // Keep instance not to have Sponsor Garbage Collected
               private AppDomain _sandbox;
               private ICustomPlugin[] _plugins; // I do not store real instances of Plugins, but a "CustomPluginProxy" which is known both by main AppDomain and Plugin AppDomain.
    
        // Constructor : load an assembly file in another AppDomain (sandbox)
        public PluginFile(System.IO.FileInfo f, AppDomainSetup appDomainSetup, Evidence evidence)
        {
            Directory = System.IO.Path.GetDirectoryName(f.FullName) + @"\";
            _sandbox = AppDomain.CreateDomain("sandbox_" + Guid.NewGuid(), evidence, appDomainSetup);
    
            _sandbox.Load(typeof(Loader).Assembly.FullName);
    
            // - Instanciate class "Loader" INSIDE OTHER APPDOMAIN, so we couldn't use new() which would create in main AppDomain.
            _loader = (Loader)Activator.CreateInstance(
                _sandbox,
                typeof(Loader).Assembly.FullName,
                typeof(Loader).FullName,
                false,
                BindingFlags.Public | BindingFlags.Instance,
                null,
                null,
                null,
                null).Unwrap();
    
            // - Load plugins list for assembly
            _plugins= _loader.LoadPlugins(f.FullName); 
    
    
            // - Keep object created in other AppDomain not to be "Garbage Collected". I create a sponsor. The sponsor in registed for object "Lease". The LeaseManager will check lease expiration, and call sponsor. Sponsor can decide to renew lease. I not renewed, the object is garbage collected.
            // - Here is an explanation. Source: https://stackoverflow.com/questions/12306497/how-do-the-isponsor-and-ilease-interfaces-work
            _sponsor = new RemotingSponsor(_loader);
           // Here is my SOLUTION after many hours ! I had to sponsor each MarshalByRefObject (plugins) and not only the main one that contains others !!!
           foreach (ICustomPlugin plugin in Plugins) 
            {
                ILease lease = (ILease)RemotingServices.GetLifetimeService((PluginProxy)plugin);
                lease.Register(_sponsor); // Use the same sponsor. Each Object lease could have as many sponsors as needed, and each sponsor could be registered in many Leases.
            }
        }
    
     }
