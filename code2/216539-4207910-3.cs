<pre>
using System;
using System.Windows;
using ClassLibrary1;
namespace _4206499
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Source = new Source();
			DataContext = Source;
		}
		public Source Source { get; set;}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Source.Description = DateTime.Now.ToString();
		} 
	}
}
</pre>
