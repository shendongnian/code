    var credentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal(client,key,tenant,AzureEnvironment.AzureGlobalCloud);
    var azure = Azure.Configure().Authenticate(credentials).WithSubscription(SubscriptionId);
    var sqlserver=azure.SqlServers.GetById("/subscriptions/<your subscrption id>/resourceGroups/<your resource group name>/providers/Microsoft.Sql/servers/<your server name>");
    var database = sqlserver.Databases.Define("test").WithEdition("GeneralPurpose").WithServiceObjective("GP_S_Gen5_1").Create();
    Console.WriteLine(database.ServiceLevelObjective);
    Console.WriteLine(database.Edition);
    Console.WriteLine(database.Name);
    Console.ReadLine();
