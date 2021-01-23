    /// <summary>
    /// Allows you to create aliases that can be used for model properties at
    /// model binding time (i.e. when data comes in from a request).
    /// 
    /// The type needs to be using the DefaultModelBinderEx model binder in 
    /// order for this to work.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class BindAliasAttribute : Attribute
    {
      public BindAliasAttribute(string alias)
      {
        //ommitted: parameter checking
        Alias = alias;
      }
      public string Alias { get; private set; }
    }
