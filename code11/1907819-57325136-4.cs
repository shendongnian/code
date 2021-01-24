 		private void Count()
		{
			int count = 0;
			foreach (UtilitiesModel item in UnitPerStrip)
			{
				if (item.IsChecked) count++;
			}
			MessageBox.Show(count.ToString());
		}
