    using System.Windows;
    using System.Windows.Controls;
    
    namespace PersonTests
    {
    	public partial class MainPage : UserControl
    	{
    		public MainPage()
    		{
    			InitializeComponent();
    			this.DataContext = new PersonViewModel();
    		}
    
    		private void button1_Click(object sender, RoutedEventArgs e)
    		{
    			(this.DataContext as PersonViewModel).CurrentPerson = new Person("Mike", "Smith");
    		}
    
    		private void button2_Click(object sender, RoutedEventArgs e)
    		{
    			(this.DataContext as PersonViewModel).CurrentPerson = new Person("Anne", "Aardvark");
    
    		}
    	}
    }
