    public class LocalizedDisplayNameAttribute : DisplayNameAttribute {
    	public LocalizedDisplayNameAttribute(string expression) : base(expression) { }
    	
    	public override string DisplayName {
    		get {
    			try	{
    				string[] vals = base.DisplayName.Split(',');
    				if(vals != null && vals.Length == 2)
    					return (string)HttpContext.GetGlobalResourceObject(vals[0].Trim(), vals[1].Trim());
    			} catch {}
    			return "{res:" + base.DisplayName + "}";
    		}
    	}
    }
