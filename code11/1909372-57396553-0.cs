    public class ClientTenantFilter : IClientFilter
    {
            public void OnCreating(CreatingContext filterContext)
            {
               if (filterContext == null) throw new ArgumentNullException(nameof(filterContext));
    
                filterContext.SetJobParameter("TenantId", TenantCurrentService.TenantId);
            }
    }
