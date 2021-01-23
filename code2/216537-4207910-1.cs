<pre>
using System;
using System.ComponentModel;
using System.Windows;
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
	public class Source : INotifyPropertyChanged
	{
		private String _Description;
		public String Description
		{
			get { return _Description; }
			set
			{
				if (_Description == value)
					return;
				_Description = value;
				OnPropertyChanged("Description");
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler != null)
			{
				var e = new PropertyChangedEventArgs(propertyName);
				handler(this, e);
			}
		}
	}
}
</pre>
