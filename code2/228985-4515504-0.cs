    private static Control GetControlByName(string controlName, Control.ControlCollection parent)
    {
      Control c = null;
      foreach (Control ctrl in parent)
      {
        if (ctrl.Name.Equals(controlName))
        {
          c = ctrl;
          return c;
        }
        if (ctrl.GetType() == typeof(ToolStrip))
        {
          foreach (ToolStripItem item in ((ToolStrip)ctrl).Items)
          {
            if (item.Name.Equals(controlName))
            {
              switch (item.GetType().Name)
              {
                case "ToolStripComboBox":
                  c = ((ToolStripComboBox)item).Control;
                  break;
                case "ToolStripTextBox":
                  c = ((ToolStripTextBox)item).Control;
                  break;
              }
              if (c != null)
              {
                break;
              }
            }
          }
        }
        if (c == null)
          c = GetControlByName(controlName, ctrl.Controls);
        else
          break;
      }
      return c;
    }
