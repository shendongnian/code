	public class MainViewModel : ViewModelBase
	{
		public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
		private static double _XPos;
		public static double XPos
		{
			get { return _XPos; }
			set
			{
				if (_XPos != value)
				{
					_XPos = value;
					StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs("XPos"));
				}
			}
		}
		public MainViewModel()
		{
			// simulate values being read by the serial port
			Task.Run(async () =>
			{
				var rng = new Random();
				while (true)
				{
					await Task.Delay(TimeSpan.FromMilliseconds(500));
					XPos = rng.Next();
				}
			});
		}
	}
