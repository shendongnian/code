 var vault1 = azure.Vaults.GetByResourceGroup();
              var  vault1 = vault1.Update()
                        .DefineAccessPolicy()
                            .ForServicePrincipal("your application id")
                            .AllowKeyAllPermissions()
                            .Attach()
                        .Apply();
           var key = vault1.Keys.Define(keyname)
                  .WithKeyTypeToCreate(JsonWebKeyType.RSA)
                  .WithKeyOperations(JsonWebKeyOperation.ALL_OPERATIONS)
                  .Create();
            var sql =azure.SqlServers.GetByResourceGroup(groupName, name);
            SqlServerKey sqlServerKey= sql.ServerKeys.Define().WithAzureKeyVaultKey(key.JsonWebKey.Kid)
                 .Create();
