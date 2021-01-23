		public class ViewModel : INotifyPropertyChanged
		{
			public event PropertyChangedEventHandler PropertyChanged;
			public List<string> Items { get; set; }
			private string _selectedItem;
			private string _previouslySelectedItem;
			public string SelectedItem
			{
				get
				{
					return _selectedItem;
				}
				set
				{
					_previouslySelectedItem = _selectedItem;
					_selectedItem = value;
					if (PropertyChanged != null)
					{
						PropertyChanged(this, new PropertyChangedEventArgs("SelectedItem"));
					}
					SynchronizationContext.Current.Post(selectionChanged, null);
				}
			}
			private void selectionChanged(object state)
			{
				if (SelectedItem != Items[0])
				{
					MessageBox.Show("Cannot select that");
					SelectedItem = Items[0];
				}
			}
			public ViewModel()
			{
				Items = new List<string>();
				for (int i = 0; i < 10; ++i)
				{
					Items.Add(string.Format("Item {0}", i));
				}
			}
		}
