    namespace My.Web
    {
        public class SessionModule : IHttpModule {
            public void Init(HttpApplication context) {
                context.BeginRequest += context_BeginRequest;
                context.EndRequest += context_EndRequest;
            }
        
            void context_BeginRequest(object sender, EventArgs e) {
                var session = DependencyResolver.Current.GetService<ISession>();
                session.Transaction.Begin();
            }
    
            void context_EndRequest(object sender, EventArgs e) {
                var session = DependencyResolver.Current.GetService<ISession>();
                session.Transaction.Commit();
                session.Dispose(); 
            }
    
            public void Dispose() {}
        }
    }
