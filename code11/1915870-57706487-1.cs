    private async void ProvisionButton_Click(object sender, RoutedEventArgs e)
    {
        ProvisionButton.IsEnabled = false;
    
        // Open the installation folder
        var installLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
    
        // Access the provisioning file
        var provisioningFile = await installLocation.GetFileAsync("ProvisioningData.xml");
    
        // Load with XML parser
        var xmlDocument = await XmlDocument.LoadFromFileAsync(provisioningFile);
    
        // Get raw XML
        var provisioningXml = xmlDocument.GetXml();
    
        // Create ProvisiongAgent Object
        var provisioningAgent = new ProvisioningAgent();
    
        try
        {
            // Create ProvisionFromXmlDocumentResults Object
            var result = await provisioningAgent.ProvisionFromXmlDocumentAsync(provisioningXml);
    
            if (result.AllElementsProvisioned)
            {
                rootPage.NotifyUser("Provisioning was successful", NotifyType.StatusMessage);
            }
            else
            {
                rootPage.NotifyUser("Provisioning result: " + result.ProvisionResultsXml, NotifyType.ErrorMessage);
            }
        }
        catch (System.Exception ex)
        {
            // See https://docs.microsoft.com/en-us/uwp/api/windows.networking.networkoperators.provisioningagent.provisionfromxmldocumentasync
            // for list of possible exceptions.
            rootPage.NotifyUser($"Unable to provision: {ex}", NotifyType.ErrorMessage);
        }
    
        ProvisionButton.IsEnabled = true;
    }
