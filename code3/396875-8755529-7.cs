        //provides access to multiple ManagementMethods
    [Serializable(), ParseChildren(true)]
    public class ManagementDelegate
    {
         [Browsable(true), EditorBrowsable(EditorBrowsableState.Always),
         PersistenceMode(PersistenceMode.InnerProperty)]
         public List<ManagementMethod> Methods
         {
             get; set;
         }
    }
    
    //provides access to multiple ManagementParameters and the method name
    [Serializable(), PersistChildren(false),TypeConverter(typeof(ExpandableObjectConverter))]
    public class ManagementMethod
    {
         [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
         public string Name
         {
             get; set;
         }
         [Browsable(true), EditorBrowsable(EditorBrowsableState.Always),
         PersistenceMode(PersistenceMode.InnerProperty)]
         public List<ManagementParameter> Parameters
         {
             get; set;
         }
    }
    //describes a parameter of method.
    [Serializable(), PersistChildren(false),TypeConverter(typeof(ExpandableObjectConverter))]
    public class ManagementParameter
    {
         [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
         public string ParameterName
         {
             get; set;
         }
    }
    //===============================
    //here is the part of user control code behind that uses the ManagementDelegate class.
    [Browsable(true), EditorBrowsable(EditorBrowsableState.Always),
    PersistenceMode(PersistenceMode.InnerProperty)]
    public ManagementDelegate SelectDelegate
    {
        get; set;
    }
    
    
    
