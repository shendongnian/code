    public class CustomAdoTemplate : Spring.Data.Generic.AdoTemplate {
    
    	public object DbProviders {
    		get;
    		set;
    	}
    	
    	public override object DbProvider {
    		get {
    			return DbProviders[GetCurrentEnvironmentKey()];
    		}
    	}
    }
