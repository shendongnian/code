    using Microsoft.Practices.Unity;
    
    public class Repo
    {
       [InjectionConstructor]
       public Repo() : this(ConfigurationManager.AppSettings["identity"], ConfigurationManager.AppSettings["password"])
       {
       }
       public Repo(string identity,string password)
       {
           //Initialize properties.
       }
    }
