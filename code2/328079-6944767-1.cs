    public interface IScreen
    {
      void DoStuff();
    }
    
    public class TouchScreen : IScreen
    {
      public void DoStuff()
      { }
    }
    
    public class NonTouchScreen : IScreen
    {
      public void DoStuff()
      { }
    }
    public partial class ScreenForm : Form
    {
      IScreen _ScreenType;
    
      public ScreenForm(IScreen screenType)
      {
        InitializeComponent();
        _ScreenType = screenType;
      }
    }
