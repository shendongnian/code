	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		int A, B;
		bool ButtonEnabledProp
		{
			get
			{
				return ((A + B) >= 5);
			}
		}
		public MainWindow()
		{
			InitializeComponent();
			A = B = 3;
			NotifyPropertyChanged("ButtonEnabledProp");
		}
		
		public event PropertyChangedEventHandler PropertyChanged;
	
		private void NotifyPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}
	}
