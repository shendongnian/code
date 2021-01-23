    public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			var model = new SampleModel();
			model.MaxWeight = 5767;
			this.Model = model;
		}
		public SampleModel Model
		{
			get
			{
				return (SampleModel)this.DataContext;	
			}
			set 
			{
				this.DataContext = value;
			}
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			this.Model.MaxWeight = 999;
			this.Model.IsFirstChecked = null;
		}
	}
