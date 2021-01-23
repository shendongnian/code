    public class ButtonEx : Button
    {
      public enum ButtonStateStyles
      {
        None,
        Pause,
        Play,
      }
      private ButtonStateStyles _ButtonStateStyle = ButtonStateStyles.None;
      public ButtonStateStyles ButtonStateStyle
      {
        get { return _ButtonStateStyle; }
        set
        {
          _ButtonStateStyle = value;
          switch (_ButtonStateStyle)
          {
            case ButtonStateStyles.Pause:
              {
                base.Image = new PauseButtonStyle().GetImage();
                break;
              }
            case ButtonStateStyles.Play:
              {
                base.Image = new PlayButtonStyle().GetImage();
                break;
              }
            default:
              {
                base.Image = null;
                break;
              }
          }
        }
      }
    }
