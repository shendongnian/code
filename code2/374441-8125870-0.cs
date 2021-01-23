    public bool DisplayAdminOnlyMenuItems
    {
      get { return menuItem1ToHide.Visible; }
      set
      {
         menuItem1ToHide.Visible = value;
         menuItem2ToHide.Visible = value;
      }
    }
