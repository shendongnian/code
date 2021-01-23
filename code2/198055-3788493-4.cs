    static class WebHelper
    {
      public static IList<T> FindControlsByType<T>(Control root) 
        where T : Control
      {
        List<T> controls = new List<T>();
        FindControlsByType<T>(root, controls);
        return controls;
      }
      private static void FindControlsByType<T>(Control root, IList<T> controls)
        where T : Control
      {
        foreach (Control control in root.Controls)
        {
          if (control is T)
          {
            controls.Add(control as T);
          }
          if (control.Controls.Count > 0)
          {
            FindControlsByType<T>(control, controls);
          }
        }
      }
    }
