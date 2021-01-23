    namespace YourApp.Web 
    { 
        [EnableClientAccess] 
        public class WcfRelayDomainService : DomainService 
        { 
            public IQueryable<Restaurant> GetRestaurants() 
            { 
                // You should create a method that wraps your WCF call
                // and returns the result as IQueryable;
                IQueryable<MyDto> mydtos = RemoteWCF.QueryMethod().ToQueryable();
                return mydtos; 
            } 
            public void UpdateDTO(MyDto dto) 
            { 
                // For update or delete, wrap the calls to the remote
                // service in your RIA services like this.
                RemoteWCF.UpdateMethod(dto);
            }
        }
    }
