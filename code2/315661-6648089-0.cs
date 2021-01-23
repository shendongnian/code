    public class CultureDrivenDisplayNameAttribute : DisplayNameAttribute
    {
      private readonly string _displayName = null;
      public CultureDrivenDisplayNameAttribute(Type resourceType,
        string resourceNameLookup)
      {
        //TODO: check for null args
        //get the ResourceManager member
        var prop = resourceType.GetProperty(
          "ResourceManager", 
          System.Reflection.BindingFlags.Public 
            | System.Reflection.BindingFlags.Static);
        //TODO: check for null or unexpected property type.
        System.Resources.ResourceManager resourceManager = 
          prop.GetValue(null, null) as System.Resources.ResourceManager;
        //TODO: check for null
        //ResourceManager is used as it lets us specify the culture - we need this
        //to be able to lookup first on Culture, then by UICulture.
        string finalResourceName = 
          resourceManager.GetString(resourceNameLookup, 
            Thread.CurrentThread.CurrentCulture);
        //TODO: check for null/whitespace resource value
        _displayName = resourceManager.GetString(finalResourceName, 
          Thread.CurrentThread.CurrentUICulture);
        //TODO: check for null display name
      }
      public override string DisplayName
      {
        get
        {
          return _displayName;
        }
      }
    }
