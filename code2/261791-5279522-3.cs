    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Documents;
    namespace pic_viewer
    {
        public partial class MainWindow : Window
       {
            public MainWindow()
            {
               InitializeComponent();
            }
        }
        public class Pic
        {
            public List<string> get_pics()
            {            
                List<string> p = new List<string>();
                p.Add(@"pack://siteoforigin:,,,/Images/black.png");
                p.Add(@"pack://siteoforigin:,,,/Images/blu.png");
                p.Add(@"pack://siteoforigin:,,,/Images/empty.png");
                p.Add(@"pack://siteoforigin:,,,/Images/red.png");
                return p;
            }
        }
    }
