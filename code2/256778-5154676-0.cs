    public static bool IsHosted()
    {
      try
      {
        var webAssemblies = AppDomain.CurrentDomain.GetAssemblies()
          .Where(a => a.FullName.StartsWith("System.Web"));
        foreach(var webAssembly in webAssemblies)
        {
          var hostingEnvironmentType = webAssembly.GetType("System.Web.Hosting.HostingEnvironment");
          if (hostingEnvironmentType != null)
          {
            var isHostedProperty = hostingEnvironmentType.GetProperty("IsHosted",
              BindingFlags.GetProperty | BindingFlags.Static | BindingFlags.Public);
            if (isHostedProperty != null)
            {
              object result = isHostedProperty.GetValue(null, null);
              if (result is bool)
              {
                return (bool) result;
              }
            }
          }
        }
      }
      catch (Exception)
      {
        // Failed to find or execute HostingEnvironment.IsHosted; assume false
      }
      return false;
    }
