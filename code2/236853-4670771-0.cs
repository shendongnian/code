		private ObservableCollection<Employee> gridData = new ObservableCollection<Employee>();
		public ObservableCollection<Employee> GridData
		{
			get { return gridData; }
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			GridData.Add(new Employee(TB.Text, "Beatles?"));
		}
