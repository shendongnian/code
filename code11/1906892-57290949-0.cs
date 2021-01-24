	private void OnValidationEvent(ValidationEventArgs e)
	{
		var row = BoekingDatagrid.GetDataGridRow();
		
		if (row != null)
		{
			if (e.HasErrors)
			{
				if (!row.BindingGroup.HasValidationError)
				{
					row.BorderBrush = new SolidColorBrush(Colors.Red);
					row.BorderThickness = new Thickness(1);
				}
				else
				{
					row.BorderThickness = new Thickness(0);
				}
			}
			else
			{
				row.BorderThickness = new Thickness(0);
			} 
		}
	}
