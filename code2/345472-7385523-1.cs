	public class Settings
	{
		public string GeminiURL;
		private LogSettings _log;
		public LogSettings Log
		{
			get { return _log = _log ?? new LogSettings(); }
			set { _log = value; }
		}
		public string Language;
		public Settings()
		{
			// defaule settings can be assigned here;
		}
	}
	public class LogSettings
	{
		public bool Debug;
		public bool Info = true;
		public bool Warn = true;
		public string FileName;
	}
