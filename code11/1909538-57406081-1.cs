    public string GetComputationalResources()
    {
        string results = null;
    
        try
        {
            var azureSku = Environment.GetEnvironmentVariable("WEBSITE_SKU");
            if (!string.IsNullOrWhiteSpace(azureSku))
            {
                // We're in Azure. Get more information!
    
                var cpuCount = Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS")?.Trim();
                var cpuId = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER")?.Trim();
                var computeMode = Environment.GetEnvironmentVariable("WEBSITE_COMPUTE_MODE")?.Trim();
                var websiteMode = Environment.GetEnvironmentVariable("WEBSITE_SITE_MODE")?.Trim();
                results = $"{azureSku} {computeMode} {websiteMode} | {cpuCount}x {cpuId}";
            }
    
        }
        catch
        {
            results = null;
        }
    
        if (results == null)
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT Name FROM Win32_Processor"))
                {
                    foreach (var item in searcher.Get())
                    {
                        results = item["Name"].ToString().Trim();
                    }
                }
            }
            catch
            {
                results = "Unknown CPU";
            }
        }
    
        return results;
    }
