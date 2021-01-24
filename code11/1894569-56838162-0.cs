    class Program
    {
        private static string bearerToken = Configuration.Token;
        private static string subscriptionId = Configuration.SubscriptionId;
        private static string resourceGroupName = Configuration.ResourceGroup;
        private static string vmName = Configuration.VMName;
        static void Main(string[] args)
        {
            using(var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", bearerToken);
    
                var result = client.GetStringAsync(new Uri($"https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/schedules/shutdown-computevm-{vmName}?api-version=2018-10-15-preview")).Result;
    
                Console.WriteLine(result);
            }
    
            Console.ReadLine();
        }
    }
