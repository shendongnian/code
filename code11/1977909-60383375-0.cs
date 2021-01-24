     @page "/"
     @using System.Linq;
     @using System.Reflection;
     <button type="button" @onclick="@GetRouteUrlWithAuthorizeAttribute">Get Route 
         Url With Authorize Attribute</button>
     @code{
          private Task GetRouteUrlWithAuthorizeAttribute()
          {
       
              // Get all the components whose base class is ComponentBase
              var components = Assembly.GetExecutingAssembly()
                                     .ExportedTypes
                                     .Where(t => 
                                    t.IsSubclassOf(typeof(ComponentBase)));
              foreach (var component in components)
              {
                  // Print the name (Type) of the Component
                  Console.WriteLine(component.ToString());
                 // Now check if this component contains the Authorize attribute
                 var allAttributes = component.GetCustomAttributes(inherit: true);
                 var authorizeDataAttributes = 
                                 allAttributes.OfType<IAuthorizeData>().ToArray();
                 // If it does, show this to us... 
                 foreach (var authorizeData in authorizeDataAttributes)
                 {
                    Console.WriteLine(authorizeData.ToString());
                 }
            }
        return Task.CompletedTask;
      }
     } 
