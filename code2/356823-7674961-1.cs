    using System.Windows;
    
    namespace WpfApp1
    {
    	/// <summary>
    	/// Interaction logic for MainWindow.xaml
    	/// </summary>
    	public partial class MainWindow : Window
    	{
    		public MainWindow()
    		{
    			InitializeComponent();
    		}
    
    		private void Button_Click(object sender, RoutedEventArgs e)
    		{
    			myMenu.SelectedValue = ++_counter;
    			if (_counter > 3) _counter = 0;
    		}
    
    		private int _counter = 0;
    
    	}
    }
