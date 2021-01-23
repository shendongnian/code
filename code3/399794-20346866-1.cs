		private static System.Windows.Forms.ErrorProvider GetErrorProvider(System.Windows.Forms.Control control)
		{
			try
			{
				//get the containing form of the control
				System.Windows.Forms.IContainerControl form = control.GetContainerControl();
				//use reflection to get to "components" field
				System.Reflection.FieldInfo componentField = form.GetType().GetField("components", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
				if (componentField != null)
				{
					//get the component collection from field
					object components = componentField.GetValue(form);
					object oReturn = null;
					//locate the ErrorProvider within the collection
					foreach (object o in ((System.ComponentModel.Container)components).Components)
					{
						if (o.GetType() == typeof(System.Windows.Forms.ErrorProvider))
						{
							oReturn = o;
							break;
						}
					}
					return (ErrorProvider)oReturn;
				}
			}
			catch 
			{
				return null;
			}
			return null;
		}
