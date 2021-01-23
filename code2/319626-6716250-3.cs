	public partial class MainWindow : Window
	{
		ViewModel vm;
		public MainWindow()
		{
			InitializeComponent();
			vm = new ViewModel();
			this.DataContext = vm;
		}
		//public int Count
		//{
		//    get { return (int)GetValue(CountProperty); }
		//    set { SetValue(CountProperty, value); }
		//}
		//// Using a DependencyProperty as the backing store for Count.  This enables animation, styling, binding, etc...
		//public static readonly DependencyProperty CountProperty =
		//    DependencyProperty.Register("Count", typeof(int), typeof(MainWindow), new UIPropertyMetadata(12));
		private void button1_Click(object sender, RoutedEventArgs e)
		{
			vm.UpdateCount();
		}
		
	}
	public class ViewModel : INotifyPropertyChanged
	{
		public ViewModel()
		{
		}
		private int dependOne = 0;
		public int DependOne
		{
			get
			{
				return dependOne;
			}
			set
			{
				dependOne = value;
				OnPropertyChanged("DependOne");
			}
		}
		private int dependTwo = 0;
		public int DependTwo
		{
			get
			{
				return dependTwo;
			}
			set
			{
				dependTwo = value;
				OnPropertyChanged("DependTwo");
			}
		}
		#region --  INotifyPropertyChanged Members  --
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged(string propertyNameArg)
		{
			PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyNameArg));
			}
		}
		#endregion
		internal void UpdateCount()
		{
			DependOne = 3;
			DependTwo = 4;
		}
	}
	public class MyConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			var dependOne = (int)values[0];
			var dependTwo = (int)values[1];
			return (dependOne + dependTwo).ToString();
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
