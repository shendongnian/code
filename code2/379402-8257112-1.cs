    interface IMedia
    {
        string Name { get; }
    }
    class ActivityMedia : IMedia
    class AuditMedia : IMedia
    class VehicleMedia : IMedia
    
    static class MediaExtensions
    {
       public static string GetName(this IMedia instance)
       {
              return instance.Name;
       }
    }
