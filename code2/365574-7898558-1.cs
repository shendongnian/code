	namespace WpfApplication1
	{
		public class MonthCal : Window
		{
			public DayOfWeek StartDayOfWeek { get { return (DayOfWeek)GetValue(StartDayOfWeekProperty); } set { SetValue(StartDayOfWeekProperty, value); } }
			public static readonly DependencyProperty StartDayOfWeekProperty = 
				DependencyProperty.Register("StartDayOfWeek", typeof(DayOfWeek), typeof(MonthCal), new UIPropertyMetadata(DayOfWeek.Sunday, StartDayOfWeek_PropertyChanged));
			private static void StartDayOfWeek_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
			{
			}
		}
		public partial class MainWindow : MonthCal
		{
			public MainWindow()
			{
				InitializeComponent();
			}
		}
	}
