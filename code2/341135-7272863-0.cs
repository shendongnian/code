    class ControlBoundValueDescription
    {
      public Control Control;
      
      public String Value
      {
        get
        {
          if(Control is ...) return ...
          ...
        }
        set
        {
          if(Control is ...) ((Xxx)Control).Yyy = value;
          ...
        }
      }
    }
    ...
    Dictionary<string, ControlBoundValueDescription> dictControls = 
      new Dictionary<string, ControlBoundValueDescription>(); 
    dictControls["UserName"].Value = "guest"; // probably, text box
    dictControls["Group"].Value = "Guest Users"; // probably, combo
