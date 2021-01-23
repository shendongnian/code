    /// <summary>
    /// Represents a <see cref="AppDomainManager"/> that is
    /// aware of the primary application AppDomain.
    /// </summary>
    public class PrimaryAppDomainManager : AppDomainManager
    {
        private static AppDomain _primaryDomain;
        /// <summary>
        /// Gets the primary domain.
        /// </summary>
        /// <value>The primary domain.</value>
        public static AppDomain PrimaryDomain
        {
            get
            {
                return _primaryDomain;
            }
        }
        /// <summary>
        /// Sets the primary domain.
        /// </summary>
        /// <param name="primaryDomain">The primary domain.</param>
        private void SetPrimaryDomain(AppDomain primaryDomain)
        {
            _primaryDomain = primaryDomain;
        }
        /// <summary>
        /// Sets the primary domain to self.
        /// </summary>
        private void SetPrimaryDomainToSelf()
        {
            _primaryDomain = AppDomain.CurrentDomain;
        }
        /// <summary>
        /// Determines whether this is the primary domain.
        /// </summary>
        /// <value>
        /// 	<see langword="true"/> if this instance is the primary domain; otherwise, <see langword="false"/>.
        /// </value>
        public static bool IsPrimaryDomain
        {
            get
            {
                return _primaryDomain == AppDomain.CurrentDomain;
            }
        }
        /// <summary>
        /// Creates the initial domain.
        /// </summary>
        /// <param name="friendlyName">Name of the friendly.</param>
        /// <param name="securityInfo">The security info.</param>
        /// <param name="appDomainInfo">The AppDomain setup info.</param>
        /// <returns></returns>
        public static AppDomain CreateInitialDomain(string friendlyName, Evidence securityInfo, AppDomainSetup appDomainInfo)
        {
            if (AppDomain.CurrentDomain.DomainManager is PrimaryAppDomainManager)
                return null;
            appDomainInfo = appDomainInfo ?? new AppDomainSetup();
            appDomainInfo.AppDomainManagerAssembly = typeof(PrimaryAppDomainManager).Assembly.FullName;
            appDomainInfo.AppDomainManagerType = typeof(PrimaryAppDomainManager).FullName;
            var appDomain = AppDomainManager.CreateDomainHelper(friendlyName, securityInfo, appDomainInfo);
            ((PrimaryAppDomainManager)appDomain.DomainManager).SetPrimaryDomainToSelf();
            _primaryDomain = appDomain;
            return appDomain;
        }
        /// <summary>
        /// Returns a new or existing application domain.
        /// </summary>
        /// <param name="friendlyName">The friendly name of the domain.</param>
        /// <param name="securityInfo">An object that contains evidence mapped through the security policy to establish a top-of-stack permission set.</param>
        /// <param name="appDomainInfo">An object that contains application domain initialization information.</param>
        /// <returns>A new or existing application domain.</returns>
        /// <PermissionSet>
        /// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="ControlEvidence, ControlAppDomain, Infrastructure"/>
        /// </PermissionSet>
        public override AppDomain CreateDomain(string friendlyName, Evidence securityInfo, AppDomainSetup appDomainInfo)
        {
            appDomainInfo = appDomainInfo ?? new AppDomainSetup();
            appDomainInfo.AppDomainManagerAssembly = typeof(PrimaryAppDomainManager).Assembly.FullName;
            appDomainInfo.AppDomainManagerType = typeof(PrimaryAppDomainManager).FullName;
            var appDomain = base.CreateDomain(friendlyName, securityInfo, appDomainInfo);
            ((PrimaryAppDomainManager)appDomain.DomainManager).SetPrimaryDomain(_primaryDomain);
            return appDomain;
        }
    }
