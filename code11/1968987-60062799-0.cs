    public static async Task CreateNamespaces(List<string> eventhubNames, ServiceClientCredentials creds) {
    int totalEventHubsInNamespace = 0;
    var ehClient = new EventHubManagementClient(creds)
    {
        SubscriptionId = "<my subscription id>"
    };
    foreach (var ehName in eventhubNames)
    {
        if (totalEventHubsInNamespace == 0)
        {
            var namespaceParams = new EHNamespace()
            {
                Location = "<datacenter location>"
            };
            // Create namespace
            var namespaceName = "<populate some unique namespace>";
            Console.WriteLine($"Creating namespace... {namespaceName}");
            await ehClient.Namespaces.CreateOrUpdateAsync(resourceGroupName, namespaceName, namespaceParams);
            Console.WriteLine("Created namespace successfully.");
        }
        // Create eventhub.
        Console.WriteLine($"Creating eventhub {ehName}");
        var ehParams = new Eventhub() { }; // Customize you eventhub here if you need.
        await ehClient.EventHubs.CreateOrUpdateAsync(resourceGroupName, namespaceName, ehName, ehParams);
        Console.WriteLine("Created Event Hub successfully.");
        totalEventHubsInNamespace++;
        if (totalEventHubsInNamespace >= 10)
        {
            totalEventHubsInNamespace = 0;
        }
    }
}
