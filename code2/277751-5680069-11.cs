	public class MyControl : ContentControl
	{
		public interface IMyControlSettings
		{
			public bool LabelsShown { get; set; }
		}
		private IMyControlSettings _settings;
		public MyControl(IMyControlSettings settings)
		{
			_settings = settings;
			DataContext = _settings; // For easy binding, in most cases you probably do not want to do that since it prevents DataContext inheritance.
		}
	}
