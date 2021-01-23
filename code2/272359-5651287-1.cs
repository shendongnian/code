	using System;
	using System.Collections.ObjectModel;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Data;
	using System.ComponentModel;
	namespace DataGridTest
	{
		/// <summary>
		/// Interaction logic for MainWindow.xaml
		/// </summary>
		public partial class MainWindow : Window
		{
			private ObservableCollection<MyObject> myObjectList = new ObservableCollection<MyObject>();
			public MainWindow()
			{
				InitializeComponent();
				(this.FindResource("MyObjectCollection") as CollectionViewSource).Source = this.myObjectList;
				this.myObjectList.Add(new MyObject() { First = "Bob", Last = "Jones" });
				this.myObjectList.Add(new MyObject() { First = "Jane", Last = "Doe" });
			}
			private void Button_Click(object sender, RoutedEventArgs e)
			{
				this.myObjectList[0].Last = "BillyOBrian";
			}
			private void dg_TargetUpdated(object sender, DataTransferEventArgs e)
			{
				dg.Columns[0].Width = 0;
				dg.UpdateLayout();
				dg.Columns[0].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
			}
		}
		public class MyObject : INotifyPropertyChanged
		{
			private string firstName;
			public string First
			{
				get { return this.firstName; }
				set
				{
					if (this.firstName != value)
					{
						this.firstName = value;
						NotifyPropertyChanged("First");
					}
				}
			}
			private string lastName;
			public string Last
			{
				get { return this.lastName; }
				set
				{
					if (this.lastName != value)
					{
						this.lastName = value;
						NotifyPropertyChanged("Last");
					}
				}
			}
			public MyObject() { }
			#region -- INotifyPropertyChanged Contract --
			public event PropertyChangedEventHandler PropertyChanged;
			private void NotifyPropertyChanged(String info)
			{
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs(info));
				}
			}
			#endregion INotifyPropertyChanged Contract
		}
	}
