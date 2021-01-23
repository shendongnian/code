    public class CustomButton : Button
    {
      public CustomButton ()
      {
        // initialize your settings
        Normal = new ButtonSettings();
        Hovered = new ButtonSettings();
        Pressed = new ButtonSettings();
        Inactive = new ButtonSettings();
        State = ButtonState.Normal;
      }
      
      public ButtonSettings Normal { get; set; }
      public ButtonSettings Hovered { get; set; }
      public ButtonSettings Pressed { get; set; }
      public ButtonSettings Inactive { get; set; }
    
      public ButtonState State { get; set; }
    }
