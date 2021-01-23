      public class SessionService : ISession 
        { 
            public HttpContextBase Context { get; set; } 
     
            public SessionService(HttpContextBase context) 
            { 
                this.Context = context; 
            } 
    } 
