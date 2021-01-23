    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    
    namespace SilverlightApplication1
    {
    	public partial class MainPage : UserControl
    	{
    		public MainPage()
    		{
    			// Required to initialize variables
    			InitializeComponent();
    			
    			mainCanvas.MouseLeftButtonDown+=new System.Windows.Input.MouseButtonEventHandler(MainPage_MouseLeftButtonDown);
    			mainCanvas.MouseLeftButtonUp+=new System.Windows.Input.MouseButtonEventHandler(MainPage_MouseLeftButtonUp);
    			mainCanvas.MouseMove+=new System.Windows.Input.MouseEventHandler(MainPage_MouseMove);
    
                SolidColorBrush myBrush = new SolidColorBrush(Colors.Green);
    
                _curRectangle.Rect.Stroke = myBrush;
                _curRectangle.Rect.StrokeThickness = 4;
                _curRectangle.Rect.Fill = myBrush;
    		}
    
    		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
    		{
    			// TODO: Add event handler implementation here.
    		}
    
    		private void elipse_Click(object sender, System.Windows.RoutedEventArgs e)
    		{
    			// TODO: Add event handler implementation here.
    		}
            RealRect _curRectangle = null;
    		private void MainPage_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    		{
                _curRectangle = new RealRect((int)e.GetPosition(sender as Canvas).X, (int)e.GetPosition(sender as Canvas).Y, false);
                mainCanvas.Children.Insert(0, _curRectangle.Rect);
                _curRectangle.StartRect();
    		}
    
    		private void MainPage_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    		{
                if (_curRectangle != null)
                {
                    _curRectangle.ClearStartTemp();
                    _curRectangle = null;
                }
    	
    		}
    
    		private void MainPage_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
    		{
                if (_curRectangle != null)
                {
                    _curRectangle.EndX = (int)e.GetPosition(sender as Canvas).X;
                    _curRectangle.EndY = (int)e.GetPosition(sender as Canvas).Y;
                    _curRectangle.MakeReal();
                }
    
                //exampleRectangle.Rect.Width =  - Canvas.GetLeft(exampleRectangle.Rect);
                //exampleRectangle.Rect.Height =  - Canvas.GetTop(exampleRectangle.Rect);
    		}
    	}
    }
