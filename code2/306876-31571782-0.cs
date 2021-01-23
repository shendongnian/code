The name of these fields have the format &lt;PropertyName&gt;k_BackingField,the methods set and get names have the format set_PropertyName and get_PropertyName where PropertyName is the name of property.
For example, your Settings class is compiled as follows:
    [Serializable]
    public class Settings : BaseClass
    {
        public Settings(){}
        // Properties
        [CompilerGenerated]
	    private bool <Value1>k__BackingField;
        [CompilerGenerated]
	    private bool <Value2>k__BackingField;
	
	    [CompilerGenerated]
	    public void set_Value1(bool value)
	    {
		    this.<Value1>k__BackingField = value;
	    }
	    [CompilerGenerated]
	    public bool get_Value1()
	    {
		    return this.<Value1>k__BackingField;
	    } 
	    [CompilerGenerated]
	    public void set_Value2(bool value)
	    {
		    this.<Value2>k__BackingField = value;
	    }
	    [CompilerGenerated]
	    public bool get_Value2()
	    {
		    return this.<Value2>k__BackingField;
	    }
    }
