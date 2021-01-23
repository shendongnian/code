		private void contactsList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			List<ContactList> list = new List<ContactList>();
			foreach (object contactList in contactsList.SelectedItems)
			{
				list.Add(contactList as ContactList);
			}
			tagsList.ItemsSource = list;
		}
