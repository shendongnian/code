    using (serviceProxy = new OrganizationServiceProxy(config.OrganizationUri,
                    config.HomeRealmUri,
                    config.Credentials,
                    config.DeviceCredentials))
            {
                // This statement is required to enable early-bound type support.
                serviceProxy.ServiceConfiguration.CurrentServiceEndpoint.Behaviors.Add(new ProxyTypesBehavior(Assembly.GetExecutingAssembly()));
            }
