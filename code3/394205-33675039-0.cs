		public string ApplicationPath
		{
			get
			{
				if (String.IsNullOrEmpty(AppDomain.CurrentDomain.RelativeSearchPath))
				{
					return AppDomain.CurrentDomain.BaseDirectory; //exe folder for WinForms, Consoles, Windows Services
				}
				else
				{
					return AppDomain.CurrentDomain.RelativeSearchPath; //bin folder for Web Apps 
				}
			}
		}
