    public class otherClass{
      accessor = new IDs ();
      string myconst = "constant"
      Dictionary<string, Object> uiObjects = new Dictionary<string, Object>();
      foreach (Object item in accessor.UIObjects )
      {
        uiObjects.Add($"{myconst}_{item.ToString()}", item.createObject());
      }
    }
