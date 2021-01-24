    public class CalculatorServiceHostFactory : ServiceHostFactoryBase
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            return new CalculatorServiceHost(baseAddresses);
        }
    }
    
    class CalculatorServiceHost : ServiceHost
    {
        #region CalculatorServiceHost Constructor
        /// <summary>
        /// Constructs a CalculatorServiceHost. Calls into SetupUsersAndroles to 
        /// set up the user and roles that the CalculatorService allows
        /// </summary>
        public CalculatorServiceHost(params Uri[] addresses)
            : base(typeof(Service1), addresses)
        {
            SetupUsersAndRoles();
        }
        #endregion
    
        /// <summary>
        /// Sets up the user and roles that the CalculatorService allows
        /// </summary>
        internal static void SetupUsersAndRoles()
        {
            // Create some arrays for membership and role data
            string[] users = { "Alice", "Bob", "Charlie" };
            string[] emails = { "alice@example.org", "bob@example.org", "charlie@example.org" };
            string[] passwords = { "ecilA-123", "treboR-456", "eilrahC-789" };
            string[] roles = { "Super Users", "Registered Users", "Users" };
    
            // Clear out existing user information and add fresh user information
            for (int i = 0; i < emails.Length; i++)
            {
                if (Membership.GetUserNameByEmail(emails[i]) != null)
                    Membership.DeleteUser(users[i], true);
    
                Membership.CreateUser(users[i], passwords[i], emails[i]);
            }
    
            // Clear out existing role information and add fresh role information
            // This puts Alice, Bob and Charlie in the Users Role, Alice and Bob 
            // in the Registered Users Role and just Alice in the Super Users Role.
            for (int i = 0; i < roles.Length; i++)
            {
                if (Roles.RoleExists(roles[i]))
                {
                    foreach (string u in Roles.GetUsersInRole(roles[i]))
                        Roles.RemoveUserFromRole(u, roles[i]);
    
                    Roles.DeleteRole(roles[i]);
                }
    
                Roles.CreateRole(roles[i]);
    
                string[] userstoadd = new string[i + 1];
    
                for (int j = 0; j < userstoadd.Length; j++)
                    userstoadd[j] = users[j];
    
                Roles.AddUsersToRole(userstoadd, roles[i]);
            }
        }
    }
