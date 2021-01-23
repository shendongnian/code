    using System;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApplication1
    {
    	public partial class MainWindow : Window
    	{
    		public MainWindow()
    		{
    			InitializeComponent();
    		}
    
    		private void Window_Loaded(object sender, RoutedEventArgs e)
    		{
    			var textBox = new TextBox() {};
    			listBox1.Items.Add(textBox);
    
    			System.Threading.ThreadPool.QueueUserWorkItem(
    				(a) =>
    				{
    					System.Threading.Thread.Sleep(100);
    					textBox.Dispatcher.Invoke(
    						System.Windows.Threading.DispatcherPriority.Normal,
    						new Action(
    							delegate()
    							{
    								textBox.Focus();
    							}
    							));
    				}
    				);
    		}
    	}
    }
