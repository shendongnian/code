    public static bool WouldBeVisible(Control ctl) 
    {
          // Returns true if the control would be visible if container is visible
          MethodInfo mi = ctl.GetType().GetMethod("GetState", BindingFlags.Instance | BindingFlags.NonPublic);
          if (mi == null) return ctl.Visible;
          return (bool)(mi.Invoke(ctl, new object[] { 2 }));
    }
