    public class ClientsService
            {
                private readonly ClientsDbContext _context;
                private readonly IConfiguration _iconfiguration;
    
                public ClientsService(ClientsDbContext context, IConfiguration 
                                                  iconfiguration)
                {
                    _context = context;
                    _iconfiguration = iconfiguration;
                }
              
    
            }
