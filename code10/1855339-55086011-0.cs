        public override async Task<TenantDto> Create(CreateTenantDto input)
        {
            CheckCreatePermission();
            // Create tenant
            var tenant = ObjectMapper.Map<Tenant>(input);
            //this code is commented since we have single database for all tenants
            //tenant.ConnectionString = input.ConnectionString.IsNullOrEmpty()
            //    ? null
            //    : SimpleStringCipher.Instance.Encrypt(input.ConnectionString);
            
            //This would read connection string from configuration and pass it to 
           //connectionstring property of AbpTenant
            var configuration = 
           AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
            tenant.ConnectionString = SimpleStringCipher.Instance.Encrypt(configuration.GetConnectionString(OneCloudConsts.ConnectionStringName));
 
