	using System.Collections.Generic;
	using System.Windows;
	namespace WpfCombobox
	{
		public partial class MainWindow : Window
		{
			public MainWindow()
			{
				this.InitializeComponent();
			}
			public string MySimpleStringProperty { get; set; }
			public List<string> MyListProperty { get; set; } = new List<string>() { "one", "two", "three" };
			private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
			{
				MessageBox.Show($"Item is {this.MySimpleStringProperty}");
			}
		}
	}
