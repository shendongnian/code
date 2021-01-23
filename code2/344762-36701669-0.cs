    using System.Collections.Generic;
    using System.Web.UI;
    // ...
    public static List<T> GetControls<T>(ControlCollection Controls)
    where T : Control {
      List<T> results = new List<T>();
      foreach (Control c in Controls) {
        if (c is T) results.Add((T)c);
        if (c.HasControls()) results.AddRange(GetControls<T>(c.Controls));
      }
      return results;
    }
