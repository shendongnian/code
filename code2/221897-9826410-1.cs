    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    namespace WpfApplication1
    {
	public partial class MainWindow : Window
	{
		private List<TestItem> _items;
		public List<TestItem> TestItems
		{
			get
			{
				if(_items == null)
				{
					_items = new List<TestItem>();
					for(int i = 0; i < 10; i++)
						_items.Add(new TestItem{ DisplayString = i.ToString(CultureInfo.InvariantCulture), IsVisible = true});
				}
					return _items;
			}
		}
        public MainWindow()
        {
			InitializeComponent();
        }
		private void Items_Loaded(object sender, RoutedEventArgs e)
		{
			/*in background so not to freeze the UI thread*/
			Task.Factory
				.StartNew(() =>
				          	{
								foreach (var item in TestItems)
								{
									item.IsLoading = true;
									item.IsVisible = true;
									/*using sleep as quick and dirty just to slow down loading and show the animation (otherwise it's a no-no )*/
									Thread.Sleep(500);
								}
				          	}
				);
		}
	}
	public class TestItem : INotifyPropertyChanged
	{
		private string _displayString;
		private bool _isVisible;
		private bool _isLoading;
		public string DisplayString
		{
			get { return _displayString; } 
			set
			{
				if (_displayString == value) return;
				_displayString = value;
				RaisePropertyChanged("DisplayString");
			}
		}
		public bool IsVisible
		{
			get { return _isVisible; }
			set
			{
				if (_isVisible == value) return;
				_isVisible = value;
				RaisePropertyChanged("IsVisible");
			}
		}
		public bool IsLoading
		{
			get { return _isLoading; }
			set
			{
				if (_isLoading == value) return;
				_isLoading = value;
				RaisePropertyChanged("IsLoading");
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		private void RaisePropertyChanged(string propertyName)
		{
			if(PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
    }
    
