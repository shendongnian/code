    public interface IScreen
    {
      void DoStuff();
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
