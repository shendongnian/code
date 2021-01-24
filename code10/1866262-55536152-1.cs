    using System.Collections.ObjectModel;
    using System.Windows;
    
    namespace TestWpfApplication
    {
    	public partial class MainWindow : Window
    	{
    		public MainWindow()
    		{
    			InitializeComponent();
    			DataContext = this;
    		}
    
    		public Collection<object> PeopleList => new Collection<object>
    		{
    			new Person(),
    			new Student(),
    			new Person(),
    			new Student()
    		};
    	}
    }
