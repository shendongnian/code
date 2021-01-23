    static class WebHelper
    {
      public static IList<Control> FindControlsByType<T>(Control root)
      {
        List<Control> controls = new List<Control>();
        FindControlsByType<T>(root, controls);
        return controls;
      }
      private static void FindControlsByType<T>(Control root, IList<Control> controls)
      {
        foreach (Control control in root.Controls)
        {
          if (control != null && control.GetType() == typeof(T))
          {
            controls.Add(control);
          }
          if (control.Controls.Count > 0)
          {
            FindControlsByType<T>(control, controls);
          }
        }
      }
    }
