    using System.Windows;
    using System.Windows.Media;
    
    namespace WpfApplication1
    {
        public class BaseWindow : Window
        {
            public BaseWindow()
            {
                Background = Brushes.Red;
                KeyDown += (sender, e) => { if (e.Key == Key.Escape) Close(); };
            }
        }
    
        public partial class Window1 
        {
            public Window1()
            {
                InitializeComponent();
            }
        }
    }
