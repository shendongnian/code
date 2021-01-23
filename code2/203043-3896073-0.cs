    public class WebRole: RoleEntryPoint
        {
            public override bool OnStart()
                {
                #region Setup CloudStorageAccount Configuration Setting Publisher
                // This code sets up a handler to update CloudStorageAccount instances when their corresponding
                // configuration settings change in the service configuration file.
                CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) =>
                {
                    // Provide the configSetter with the initial value
                    configSetter(RoleEnvironment.GetConfigurationSettingValue(configName));
    
                    RoleEnvironment.Changed += (sender, arg) =>
                    {
                        if (arg.Changes.OfType<RoleEnvironmentConfigurationSettingChange>()
                            .Any((change) => (change.ConfigurationSettingName == configName)))
                        {
                            // The corresponding configuration setting has changed, propagate the value
                            if (!configSetter(RoleEnvironment.GetConfigurationSettingValue(configName)))
                            {
                                // In this case, the change to the storage account credentials in the
                                // service configuration is significant enough that the role needs to be
                                // recycled in order to use the latest settings. (for example, the 
                                    // endpoint has changed)
                                RoleEnvironment.RequestRecycle();
                            }
                        }
                    };
                });
                #endregion
                return base.OnStart();
            }
        }
