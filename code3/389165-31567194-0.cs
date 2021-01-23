		private bool checkSpecifiedProviderExists()
		{
			var connectionStringSettings = ConfigurationManager.ConnectionStrings["YourConnectionString"];	
			var factory = DbProviderFactories.GetFactory(connectionStringSettings.ProviderName);	
			
			try
			{
				var dbConnection = factory.CreateConnection();
				if(dbConnection !=null) return true;
					return false;
			}
			catch
			{
					return false;
			}
		}
