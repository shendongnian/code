	[XmlInclude(typeof(CanonicalUser))]
    [XmlInclude(typeof(AnotherUser))]
    public abstract class Grantee
	{
		// ...
	} 
	[XmlType(TypeName= "CanonicalUser", Namespace = "http://s3.amazonaws.com/doc/2006-03-01/")]        
	public class CanonicalUser : Grantee
	{}
	[XmlType(TypeName = "AnotherUser", Namespace = "http://s3.amazonaws.com/doc/2006-03-01/")]
	public class AnotherUser : Grantee
	{}
