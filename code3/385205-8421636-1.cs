    public class CustomButton : Button
    {
      public CustomButton ()
      {
        // initialize your settings
      }
      
      public ButtonSettings ButtonSetting { get; set; }
      public ButtonSettings Hovered { get; set; }
      public ButtonSettings Pressed { get; set; }
      public ButtonSettings Inactive { get; set; }
    
      public ButtonState State { get; set; }
    }
