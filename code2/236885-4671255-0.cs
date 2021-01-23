     public class ContextFactory {
           private List<PrincipalContext> contexts = new List<PrincipalContext>();
           public PrincipalContext GetPrincipalContext(ContextType contextType, string domainName)
           {
               PrincipalContext existingContext = contexts.First(item=>item.ContextType==contextType && 
                  item.DomainName == domainName);
               if (existingContext != null) {
                   existingContext = new PrincipalContext(contextType,domainName);
                   contexts.Add(existingContext);
               }
               return(existingContext);
            }
        }
        public void Dispose()
        {
            foreach (PrincipalContext in contexts) {
                context.Dispose();
            }
         } 
    }
