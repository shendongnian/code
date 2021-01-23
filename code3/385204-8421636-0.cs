    public class ButtonSettings
    {
      public Alignement TextAlign { get; set; }
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
