    <#@ template debug="false" hostspecific="false" language="C#" #>
    <#@ output extension=".generated.cs" #>
    <#
    var properties = new[] {
    	new Property { Type = typeof(int), Name = "CustomerID", DefaultValue = 0 },
    	new Property { Type = typeof(int), Name = "BasketID", DefaultValue = 0 },
    };
    #>
    namespace YourNameSpace {
    	public partial class YourClass {
    <# foreach (Property property in properties) { #>
    		public static <#= property.Type.FullName #> <#= property.Name #> {
    	        get { return SessionHelper.Get<int>("<#= property.Name #>", <#= property.DefaultValue #>); }
    	        set { SessionHelper.Set("<#= property.Name #>", value); }
    		}
    <# } #>
    	}
    }
    <#+
    public class Property {
    	public Type Type { get; set; }
    	public string Name { get; set; }
    	public object DefaultValue { get; set; }
    }
    #>
