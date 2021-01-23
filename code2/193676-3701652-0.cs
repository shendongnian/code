    public partial class Teacher
    {
    	[global::System.Runtime.Serialization.DataMemberAttribute()] 
    	public string FullName
    	{
    		get { return string.Format("{0} {1} {2}", Title, Forenames, Surname); }
    		set { }
    	}
    }
