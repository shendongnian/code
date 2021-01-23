        /// <summary>
        /// Returns the primary application domain.
        /// </summary>
        /// <returns>The primary application domain.</returns>
        public static AppDomain GetPrimaryAppDomain()
        {
            return GetAppDomain(Process.GetCurrentProcess().MainModule.ModuleName);
        }
        /// <summary>
        /// Returns the application domain with the given friendly name.
        /// </summary>
        /// <param name="friendlyName">The friendly name of the application domain.</param>
        /// <returns>The application domain with the given friendly name.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown if friendlyName is null.</exception>
        public static AppDomain GetAppDomain(string friendlyName)
        {
            if (friendlyName == null)
            {
                throw new ArgumentNullException("friendlyName");
            }
            IntPtr handle = IntPtr.Zero;
            CorRuntimeHostClass host = new CorRuntimeHostClass();
            try
            {
                host.EnumDomains(out handle);
                object domain = null;
                while (true)
                {
                    host.NextDomain(handle, out domain);
                    if (domain == null)
                    {
                        return null;
                    }
                    AppDomain appDomain = (AppDomain)domain;
                    if (appDomain.FriendlyName == friendlyName)
                    {
                        return appDomain;
                    }
                }
            }
            finally
            {
                host.CloseEnum(handle);
                Marshal.ReleaseComObject(host);
                host = null;
            }
        }
