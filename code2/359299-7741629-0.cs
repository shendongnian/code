    public class WebCreator
    { 
      public static SPWeb CreateWeb(SPWeb parent, string name)
      {
        return parent.Webs.Add(name);
      }
    }
