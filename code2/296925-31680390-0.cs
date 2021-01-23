			// Ask each childs to notify also, if any could (if possible)
			foreach (PropertyInfo prop in options.GetType().GetProperties())
			{
				if (prop.CanRead) // Does the property has a "Get" accessor
				{
					if (prop.GetIndexParameters().Length == 0) // Ensure that the property does not requires any parameter
					{
						var notify = prop.GetValue(options) as INotifyPropertyChanged; 
						if (notify != null)
						{
							notify.PropertyChanged += options.OptionsBasePropertyChanged;
						}
					}
					else
					{
						// Will get TargetParameterCountException if query:
						// var notify = prop.GetValue(options) as INotifyPropertyChanged;
					}
				}
			}
