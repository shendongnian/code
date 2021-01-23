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
    
    namespace WpfApplication6
    {
    	/// <summary>
    	/// Interaction logic for MainWindow.xaml
    	/// </summary>
    	public partial class MainWindow : Window
    	{
    		private bool _isRectDragInProg;
    
    		public MainWindow()
    		{
    			InitializeComponent();
    		}
    
    		private void rect_MouseLeftButtonDown( object sender, MouseButtonEventArgs e )
    		{
    			_isRectDragInProg = true;
    			rect.CaptureMouse();
    		}
    
    		private void rect_MouseLeftButtonUp( object sender, MouseButtonEventArgs e )
    		{
    			_isRectDragInProg = false;
    			rect.ReleaseMouseCapture();
    		}
    
    		private void rect_MouseMove( object sender, MouseEventArgs e )
    		{
    			if( !_isRectDragInProg ) return;
    
    			var mousePos = e.GetPosition(canvas);
    			double left = mousePos.X - (rect.ActualWidth / 2);
    			double top = mousePos.Y - (rect.ActualHeight / 2);
    			Canvas.SetLeft( rect, left );
    			Canvas.SetTop( rect, top );
    		}
    	}
    }
