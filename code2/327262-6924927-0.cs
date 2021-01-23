	using System;
	using System.IO.IsolatedStorage;
	using System.Windows;
	using Microsoft.Phone.Controls;
	
	namespace SidekickWP7
	{
		public partial class Page1 : PhoneApplicationPage
		{
			const string MYALARM = "MyAlarm";
	
			public Page1()
			{
				InitializeComponent();
	
				Loaded += new RoutedEventHandler(Page1_Loaded);
			}
	
			void Page1_Loaded(object sender, RoutedEventArgs e)
			{
				int intAlarm = 0;
				
				Int32.TryParse(Load(MYALARM).ToString(), out intAlarm);
	
				intAlarm++;
	
				MessageBox.Show(intAlarm.ToString());
	
				Save(MYALARM, intAlarm);
			}
	
			private static object Load(string strKey)
			{
				object objValue;
	
				if (IsolatedStorageSettings.ApplicationSettings.TryGetValue<object>(strKey, out objValue) == false)
				{
					objValue = String.Empty;
				}
	
				return objValue;
			}
	
			private static void Save(string strKey, object objValue)
			{
				IsolatedStorageSettings.ApplicationSettings[strKey] = objValue;
	
				IsolatedStorageSettings.ApplicationSettings.Save();
			}
		}
	}
