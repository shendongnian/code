    public class CertificateAuthorizationManager : ServiceAuthorizationManager
    {
    	protected override bool CheckAccessCore(OperationContext operationContext)
    	{
    		if (!base.CheckAccessCore(operationContext))
    		{
    			return false;
    		}
    
    		string thumbprint = GetCertificateThumbprint(operationContext);
    
    		// TODO: Check the thumbprint against your database, then return true if found, otherwise false
    	}
    
    	private string GetCertificateThumbprint(OperationContext operationContext)
    	{
    		foreach (var claimSet in operationContext.ServiceSecurityContext.AuthorizationContext.ClaimSets)
    		{
    			foreach (Claim claim in claimSet.FindClaims(ClaimTypes.Thumbprint, Rights.Identity))
    			{
    				string tb = BitConverter.ToString((byte[])claim.Resource);
    				tb = tb.Replace("-", "");
    				return tb;
    			}
    		}
    
    		throw new System.Security.SecurityException("No client certificate found");
    	}
    }
