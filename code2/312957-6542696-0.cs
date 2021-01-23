	public class AsyncConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			object result = null;
			DoAsync(() =>
			{
				Thread.Sleep(2000); // Simulate long task
				result = (int)value * 2; // Some sample conversion
			});
			return result;
		}
		private void DoAsync(Action action)
		{
			var frame = new DispatcherFrame();
			new Thread((ThreadStart)(() =>
			{
				action();
				frame.Continue = false;
			})).Start();
			Dispatcher.PushFrame(frame);
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
