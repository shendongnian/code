    class ControlBoundValueDescription
    {
      private Control _control;
      public ControlBoundValueDescription(Control control)
      {
        _control = control;
      }
      
      public string Value
      {
        get
        {
          if(_control is ...) return ...
          ...
        }
        set
        {
          if(_control is ...) ((Xxx)_control).Yyy = value;
          ...
        }
      }
    }
    ...    
    Dictionary<string, ControlBoundValueDescription> dictControls = 
      new Dictionary<string, ControlBoundValueDescription>(); 
    ...
    // defining mappings
    dictControls["UserName"] = new ControlBoundValueDescription(tbUserName);
    dictControls["Group"] = new ControlBoundValueDescription(cbxGroup);
    ...
    // working with controls using previously defined mappings
    dictControls["UserName"].Value = "guest"; // probably, text box
    dictControls["Group"].Value = "Guest Users"; // probably, combo
