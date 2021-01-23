    public class RoleConfigurationSource : IConfigurationSource
    {
        private IConfigurationSource base;
        private IConfigurationSource managerValidations;
        private IConfigurationSource adminValidations;
        public RoleConfigurationSource()
        {
            this.base = new FileConfigurationSource("validation_base.config");
            var mngr = new FileConfigurationSource("validation_manager.config");
            var admn = new FileConfigurationSource("validation_admin.config");
            managerValidations = 
                new ValidationConfigurationSourceCombiner(base, mngr);
            adminValidations =
                new ValidationConfigurationSourceCombiner(base, admn);
        }
        public ConfigurationSection GetSection(string sectionName)
        {
            if (sectionName == ValidationSettings.SectionName)
            {
                if (Roles.UserIsInRole("admin"))
                {
                    return this.adminValidations;
                }
                else
                {
                    return this.managerValidations;
                }
            }
            return null;
        }
        #region IConfigurationSource Members
        // Rest of the IConfigurationSource members left out.
        // Just implement them by throwing an exception from
        // their bodies; they are not used.
        #endregion
    }
