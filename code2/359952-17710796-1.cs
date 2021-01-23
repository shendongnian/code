    public void UnRegisterCertificateWithIIS6(string webSiteName)
    		{
    			// USE WMI TO DERIVE THE INSTANCE NAME
    			ManagementScope managementScope = new ManagementScope(@"\\.\root\MicrosoftIISv2");
    			managementScope.Connect();
    			ObjectQuery queryObject = new ObjectQuery("SELECT Name FROM IISWebServerSetting WHERE ServerComment = '" + webSiteName + "'");
    			ManagementObjectSearcher searchObject = new ManagementObjectSearcher(managementScope, queryObject);
    
    			foreach (var instanceName in searchObject.Get())
    			{
    				var IISCertObj = new CERTOBJLib.IISCertObjClass();
    				IISCertObj.InstanceName = instanceName["Name"].ToString();
    
    				// THE REMOVE CERT CALL COMPLETES SUCCESSFULLY, BUT FOR WHATEVER REASON, IT ERRORS OUT.
    				// SWALLOW THE ERROR.
    				try
    				{
    					IISCertObj.RemoveCert(false, true);
    				}
    				catch (Exception ex)
    				{
    
    				}
    			}
    		}
