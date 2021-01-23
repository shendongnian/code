    using System.Linq;
    using System.Management;
    namespace CertStuff
    {
    	public class CertificateInstaller
    	{
    public void RegisterCertificateWithIIS6(string webSiteName, string certificateFilePath, string certificatePassword)
    		{
    			// USE WMI TO DERIVE THE INSTANCE NAME
    			ManagementScope managementScope = new ManagementScope(@"\\.\root\MicrosoftIISv2");
    			managementScope.Connect();
    			ObjectQuery queryObject = new ObjectQuery("SELECT Name FROM IISWebServerSetting WHERE ServerComment = '" + webSiteName + "'");
    			ManagementObjectSearcher searchObject = new ManagementObjectSearcher(managementScope, queryObject);
    			var instanceNameCollection = searchObject.Get();
    			var instanceName = (from i in instanceNameCollection.Cast<ManagementObject>() select i).FirstOrDefault();
    
    			// USE IIS CERT OBJ TO IMPORT CERT - THIS IS A COM OBJECT
    			var IISCertObj = new CERTOBJLib.IISCertObjClass();
    			IISCertObj.InstanceName = instanceName["Name"].ToString();
    			IISCertObj.Import(certificateFilePath, certificatePassword, false, true); // OVERWRITE EXISTING
    		}
    
    	}
    }
