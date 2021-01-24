	using System.Windows;
	namespace SO60283924
	{
		public partial class MainWindow : Window
		{
			public SomeViewModel SomeViewModel
			{
				get { return (SomeViewModel)GetValue(SomeViewModelProperty); }
				set { SetValue(SomeViewModelProperty, value); }
			}
			public static readonly DependencyProperty SomeViewModelProperty =
				DependencyProperty.Register(nameof(SomeViewModel), typeof(SomeViewModel), typeof(MainWindow), new PropertyMetadata(new SomeViewModel()));
			public MainWindow()
			{
				InitializeComponent();
			}
			void Window_Loaded(object sender, RoutedEventArgs e)
			{
				SomeViewModel.PropertyChanged += (_, propertyChangedEventArgs) =>
				{
					switch (propertyChangedEventArgs.PropertyName)
					{
						case nameof(SomeViewModel.SomeDecimal):
						case nameof(SomeViewModel.SomeInt):
						case nameof(SomeViewModel.SomeObject):
						case nameof(SomeViewModel.SomeString):
							//TODO add validation code
							break;
					}
				};
			}
		}
	}
