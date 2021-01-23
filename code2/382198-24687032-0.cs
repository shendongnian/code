    public class MyResourceManager : System.Resources.ResourceManager
      {
        // override
        public override GetString(string name)
          {
            // custom code 
          }
      }
     public MyResourceDesigner
       {
          // use your custom class with override
          private static MyResourceManager resourceManager;
          private static CultureInfo resourceCulture;
          public static MyResourceManager ResourceManager
             {
                if (object.ReferenceEquals(resourceManager, null))
                   {
                      // Resource is just the name of the .resx file
                      // be sure to include relevant namespaces
                      var temp = new MyResourceManager(
                         "MyProject.Resource", 
                         typeof(MyResourceDesigner).Assembly);
                      resourceManager = temp;
                   }
              
                return resourceManager;
             }
          
          public static CultureInfo Culture
          {
             get
             {
                return resourceCulture;
             }
             set
             {
                resourceCulture = value;
             }
          }
          // start adding strongly-typed objects
          public static string Foo
          {
             get
             {
                // use your override
                return ResourceManager.GetString("Foo", resourceCulture);
             }
          }
      }
                     
