    public class ServerTenantFilter : IServerFilter
    {
        public void OnPerforming(PerformingContext filterContext)
        {
          if (filterContext == null) throw new ArgumentNullException(nameof(filterContext));
    
          var tenantId = filterContext.GetJobParameter<string>("TenantId");
          TenantCurrentService.TenantId = tenantId;
        }
    }
