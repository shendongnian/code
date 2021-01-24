    using Microsoft.Azure.Management.Insights;
    using Microsoft.Rest;
    
    //... Get necessary values for the required parameters 
    
    var client = new InsightsManagementClient(new TokenCredentials(token));
    client.AutoscaleSettings.Get(resourceGroupName, autoScaleSettingName);
