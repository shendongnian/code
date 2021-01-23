		try
		{
			BL.UpdateCustomerChanges();
			dgCustomers.Items.Refresh();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Fehler beim Speichern", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}
