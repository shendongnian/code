namespace FuncApp.MSAzure.ARMTemplates.ARMParaneterTypes
{
    public class ParameterValueString
    {
        public string Value { get; set; }
    }
    public class ParameterValueArray
    {
        public string[] Value { get; set; }
    }
    public class ParameterBoolValue
    {
        public bool Value { get; set; }
    }
}
Mapping Class method extract:
   public static AzNewVmRequestArmParameters ToArmParameters(
            this AzNewVmRequest requestContent,
            string adminUsername,
            string adminPassword
        )
	{
            return new AzNewVmRequestArmParameters
            {
                location = new ParameterValueString {
                    Value = requestContent.Location
                },
                adminUsername = new ParameterValueString
                {
                    Value = adminUsername
                },
                adminPassword = new ParameterValueString
                {
                    Value = adminPassword
                },
            };
        }
'AzNewVmRequestArmParameters' Model class extract:
namespace FuncApp.MSAzure.VirtualMachines
{
    public class AzNewVmRequestArmParameters
    {
        public ParameterValueString location { get; set; }
        public ParameterValueString adminUsername { get; set; }
        public ParameterValueString adminPassword { get; set; }
    }
}
With these, i'm able to run the following code below (simplified) to formulate a valid jObject variable with the parameters that can be ready by the API:
var parameters = azureVmDeploymentRequest.ToArmParameters(
   adminUsername: "azurevmadmin",
   adminPassword: "P@ssword123!"
);
var jParameters = JObject.FromObject(parameters);
