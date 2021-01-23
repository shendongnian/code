    interface INameAware
    {
        string name { get; }
    }
    class ActivityMedia : INameAware
    class AuditMedia : INameAware
    class VehicleMedia : INameAware
    
    static class NameAwareExtensions
    {
       public static string GetName(this INameAware instance)
       {
              return instance.Name;
       }
    }
