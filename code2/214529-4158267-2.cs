    using System.Windows.Shapes;
    
    namespace SilverlightApplication1
    {
      public partial class MainPage : UserControl
      {
        public MainPage()
        {
          InitializeComponent();
          AddEventHandlers();
        }
    
        public void AddEventHandlers()
        {
          SlideOutMenu.MouseEnter += new MouseEventHandler(SlideOutMenu_MouseEnter);
          
        }
    
        public void SlideOutMenu_MouseEnter(object sender, MouseEventArgs e)
        {
          Storyboard showMenu = Application.Current.Resources["ShowControls"] as Storyboard;
          Storyboard.SetTarget(showMenu, SlideOutMenu);
          showMenu.Begin();      
        } 
      }
    }
