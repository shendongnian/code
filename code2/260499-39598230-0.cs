    protected override CreateParams CreateParams
    {
       get
       {
          new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
    
          // Extend the CreateParams property of the Button class.
          CreateParams cp = base.CreateParams;
          // Update the button Style.
          cp.Style &= ~0xC00000; //WS_CAPTION;
          cp.Caption = PRODUCT_NAME;
    
          return cp;
       }
    }
