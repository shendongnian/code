    static class WebHelper
    {
      public static IList<Control> FindControlType<T>(Control root)
      {
        List<Control> controls = new List<Control>();
        FindControlType<T>(root, controls);
        return controls;
      }
      private static void FindControlType<T>(Control root, IList<Control> controls)
      {
        foreach (Control control in root.Controls)
        {
          if (control != null && control.GetType() == typeof(T))
          {
            controls.Add(control);
          }
          if (control.Controls.Count > 0)
          {
            FindControlType<T>(control, controls);
          }
        }
      }
    }
