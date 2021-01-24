using Microsoft.WindowsAzure.MediaServices.Client;
using System;
using System.Linq;
namespace GenerateLocatorV2
{
    class Program
    {
        private static CloudMediaContext _context = null;
        static void Main(string[] args)
        {
            string tenantDomain = args[0];
            string RESTendpoint = args[1];
            string assetId = args[2];
            // Specify your AAD tenant domain, for example "microsoft.onmicrosoft.com"
            AzureAdTokenCredentials tokenCredentials = new AzureAdTokenCredentials(tenantDomain, AzureEnvironments.AzureCloudEnvironment);
            AzureAdTokenProvider tokenProvider = new AzureAdTokenProvider(tokenCredentials);
            // Specify your REST API endpoint, for example "https://accountname.restv2.westcentralus.media.azure.net/API"
            _context = new CloudMediaContext(new Uri(RESTendpoint), tokenProvider);
            IAsset asset = GetAsset(assetId);
            // Always try to reuse access policies.  You only need to configure one per type of access (30 day, read for example). 
            var tempPolicyId = from a in _context.AccessPolicies
                               where a.Name == "30DayRead"
                               select a;
            IAccessPolicy policy = null;
            if (tempPolicyId.Count() < 1)
            {
                // This will likely only run once ever to create the policy with this specific name.
                policy = _context.AccessPolicies.Create("30DayRead",
                TimeSpan.FromDays(30),
                AccessPermissions.Read);
            }
            else
            {
                // The policy exists already and has been found.
                policy = tempPolicyId.FirstOrDefault();
            }
            // Create a locator to the streaming content on an origin. 
            ILocator originLocator = _context.Locators.CreateLocator(LocatorType.OnDemandOrigin, asset,
                policy,
                DateTime.UtcNow.AddMinutes(-5));
        }
        private static IAsset GetAsset(string assetId)
        {
            var tempAsset = from a in _context.Assets
                            where a.Id == assetId
                            select a;
            IAsset asset = tempAsset.SingleOrDefault();
            return asset;
            // This function can be done in a single line by code like:
            // IAsset asset = _context.Assets.Where(a => a.Id == assetId).FirstOrDefault();
        }
    }
}
