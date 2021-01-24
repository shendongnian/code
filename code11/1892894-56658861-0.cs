    public interface IEnterpriseDbContext
    {
       // put all exposed capabilities here, taking care to expose nothing that depends on AspNet.Identity etc.
    }
    
    public sealed class EnterpriseDbContext : IEnterpriseDbContext
    {
        private readonly IdentityDbContext<EnterpriseUser, EnterpriseRole, long, EnterpriseUserLogin, EnterpriseUserRole, EnterpriseUserClaim> _identityDbContext = null;
    
        public EnterpriseDbContext(string contextName = "DefaultEnterpriseConnection") : base(contextName)
        {
            _identityDbContext = new IdentityDbContext<EnterpriseUser, EnterpriseRole, long, EnterpriseUserLogin, EnterpriseUserRole, EnterpriseUserClaim>(contextName);
            /* Entities, Configurations and stuff */
        }
    
    // For all methods defined in your interface, pass through calls to _identityDbContext. Any ASPNet.Identity parameters or return values will need to be wrapped and translated by your own definitions.
    
    }
