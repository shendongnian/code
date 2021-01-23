<!-- -->
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Windows.Controls.Primitives;
    
    namespace WpfApplication1
    {
    	public partial class MainWindow : Window
    	{
    		public MainWindow()
    		{
    			InitializeComponent();
    
    			var tb = new ToggleButton();
    			var image = new Image();
    			BitmapImage bmi = new BitmapImage();
    			bmi.BeginInit();
    			bmi.UriSource = new Uri("/Images/6.png", UriKind.Relative);
    			bmi.EndInit();
    			image.Source = bmi;
    			tb.Content = image;
    			_Root.Children.Add(tb);
    		}
    	}
    }
