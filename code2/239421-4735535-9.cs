    public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.Model = new SampleModel();
		}
		protected SampleModel Model
		{
			get
			{
				if (this.Model.ClickCommand.CanExecute())
				{
					this.Model.ClickCommand.Execute();
				}
				return (SampleModel)this.DataContext;	
			}
			set 
			{
				this.DataContext = value;
			}
		}
	}
