    protected override void CreateChildControls()
    {
         base.CreateChildControls();
         List <PermissionPanel> panels;
         if (Page.Items["PermissionPanels"] == null)
             Page.Items["PermissionPanels"] = panels = new List <PermissionPanel>();
         else
             panels = Page.Items["PermissionPanels"] as List <PermissionPanel>;
         panels.Add(this);
    }
