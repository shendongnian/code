    protected override void OnClick(EventArgs e)
    {
       // Call the base class
       base.OnClick(e);
    
       // See if our custom drop-down is visible
       if (customDropDown.Visible)
       {
          // Set the focus to a different control on the form,
          // which will force the drop-down to close
          this.SelectNextControl(customDropDown, true, true, true, true);
       }
    }
