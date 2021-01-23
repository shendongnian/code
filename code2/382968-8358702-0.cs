    [Serializable]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public sealed class AnyRolePermissionAttribute : CodeAccessSecurityAttribute
    {
    	public AnyRolePermissionAttribute(SecurityAction action)
    		: base(action)
    	{
    	}
    
    	public string Roles { get; set; }
    
    	public override IPermission CreatePermission()
    	{
    		IList<string> roles = (this.Roles ?? string.Empty).Split(',', ';')
    								.Select(s => s.Trim())
    								.Where(s => s.Length > 0)
    								.Distinct()
    								.ToList();
    
    		IPermission result;
    		if (roles.Count == 0)
    		{
    			result = new PrincipalPermission(null, null, true);
    		}
    		else
    		{
    			result = new PrincipalPermission(null, roles[0]);
    			for (int i = 1; i < roles.Count; i++)
    			{
    				result = result.Union(new PrincipalPermission(null, roles[i]));
    			}
    		}
    
    		return result;
    	}
    }
