		/// <summary>FORM: BasicApp - Load</summary>
		private void BasicApp_Load(object sender, EventArgs e)
		{
			// Setup Main Form Caption with App Name and Config Control Info
			if (!DesignMode)
			{
				m_Globals = new Globals();
				Text = TGG.GetApplicationConfigInfo();
			}
		}
	
