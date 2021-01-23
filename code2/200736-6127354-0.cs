    #region Form Fields Enablers
    protected virtual void EnableFormFields(Control ctl)
    {
      EnableFormFields(ctl, true);
    }
    protected virtual void DisableFormFields(Control ctl)
    {
      EnableFormFields(ctl, false);
    }
    protected virtual void EnableFormFields(Control ctl, bool enable)
    {
      EnableFormFields(ctl, enable, new string[0]);
    }
    protected virtual void EnableFormFields(Control ctl, bool enable, params string[] excludeControlName)
    {
      bool exclude = false;
      foreach (string excludeCtl in excludeControlName)
      {
        if (string.Compare(ctl.Name, excludeCtl, true) == 0)
        {
          exclude = true;
          break;
        }
      }
      if (!exclude)
      {
        ctl.Enabled = enable;
        foreach (Control childCtl in ctl.Controls)
        {
          EnableFormFields(childCtl, enable, excludeControlName);
        }
      }
    }
    #endregion  Form Fields Enablers
