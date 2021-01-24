    public class FullEmployeeViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged implementation
        protected void RaisePropertyChanged([CallerMemberName]  string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        
		public bool _selectedLocationIndex { get; set; }
        public bool _employee { get; set; }
        public string _locations { get; set; }
		public string _secondPickerItemsSource { get; set; }
        #region properties
        
		
        public bool SelectedLocationIndex
        {
            get { return _selectedLocationIndex; }
            set 
			{ 
				_selectedLocationIndex = value;
				RaisePropertyChanged();
			}
        }
        
        public bool Employee
        {
            get { return _employee; }
            set { _employee = value; RaisePropertyChanged(); }
        }
        public string Locations
        {
            get { return _locations; }
            set { _locations = value; RaisePropertyChanged(); }
        }
		 public string SecondPickerItemsSource
        {
            get { return _secondPickerItemsSource; }
            set { _secondPickerItemsSource = value; RaisePropertyChanged(); }
        }
        #endregion
        public FullEmployeeViewModel()
        {
            Employee = _employee;
			Locations = await _clientBl.GetLocations();
			SelectedLocationIndex = fullEmployee.Locations.FindIndex(x => x.LocationID == _employee.LocationID);
        }
        
    }
