    namespace MyResources
    {
       public class Resources
       {
          static System.Resources.ResourceManager resourceMan =
             new System.Resources.ResourceManager("MyResources.Properties.Resources",
             typeof(Resources).Assembly);
          public static string GetString(StrId name,
             System.Globalization.CultureInfo culture = null, params string[] substitutions)
          {
             if (culture == null) culture = System.Threading.Thread.CurrentThread.CurrentUICulture;
             string format = resourceMan.GetString(name.ToString(), culture);
             if (format != null)
             {
                return string.Format(format, substitutions);
             }
             return name.ToString();
          }
       }
    }
