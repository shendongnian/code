		public Settings Settings { get; set; }
		public void OnOpen()
		{
			if ( !File.Exists( "Settings.xml" ) )
			{
				// init settings
				this.Settings = new Settings()
				{
					FullscreenAsDefault = false,
					WindowHeight = 500,
					WindowWidth = 700
				};
			}
			else
			{
				// load settings
				XmlSerializer xmlSerializer = new XmlSerializer( typeof( Settings ) );
				Settings = xmlSerializer.Deserialize( new FileStream( "Settings.xml", FileMode.Open ) ) as Settings;
			}
		}
		public void OnClose()
		{
			// save settings
			XmlSerializer xmlSerializer = new XmlSerializer( typeof( Settings ) );
			xmlSerializer.Serialize( new FileStream( "Settings.xml", FileMode.Create ), this.Settings );
		}
