    public class ButtonSettings
    {
      private ButtonSettings parentSettings;
      
      public void ButtonSettings(ButtonSettings parent)
      {
        parentSettings = parent;
        if (parent == null)
        {
          // initialize default values
          TextAlign = TextAlign.Left;
          // ...
        }
      }
      
      private Alignement textAlign = null;
      public Alignement TextAlign
      {
        get { return textAlign != null ? textAlign : (parentSettings != null ? parentSettings.TextAlign : default(Alignement)); };
        set { textAlign = value; };
      }
      
      // do the same as TextAlign ...
      public Color BackgroundColor { get; set; }
      public Color TextColor { get; set; }
      public Font Font { get; set; }
    }
    
    public enum ButtonState
    {
      Normal,
      Hovered,
      Pressed
      Inactive
    }
