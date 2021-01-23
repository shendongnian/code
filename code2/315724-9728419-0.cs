    		if (ViewModelBase.IsInDesignModeStatic)
			{
				SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
			}
			else
			{
				//SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
				SimpleIoc.Default.Register<IDataService, DataService>();
			}
