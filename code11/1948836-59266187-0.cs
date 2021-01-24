    public class CoreClass
    {
     protected IServiceCollection _serviceDescriptors;
     public CoreClass(IServiceCollection serviceDescriptors)
     {
            _serviceDescriptors = serviceDescriptors;
     }
       private List<DbContext> GetContexts()
      {
            StringBuilder sb = new StringBuilder();
            List<DbContext> listdb = new List<DbContext>();
            foreach (ServiceDescriptor sd in _serviceDescriptors
                .Where(s => s.ServiceType.IsSubclassOf(typeof(DbContext))))
            {
                sb.Append(sd.ServiceType.Name).Append(": ").AppendLine(
                    ((DbContext)HttpContext.RequestServices.GetService(sd.ServiceType))?.Database.GetDbConnection().ConnectionString);
                listdb.Add((DbContext)HttpContext.RequestServices.GetService(sd.ServiceType));
            }
            return listdb;
        }
    }
