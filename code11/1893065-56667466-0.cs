    class EmployeeViewModel : INotifyPropertyChanged
    {
        private EmployeeModel _employee;
        public DateTime? Dob
        {
            get { return _employee.Dob; }
            set { _employee.Dob = value; OnPropertyChanged(); OnPropertyChanged(nameof(Age)); }
        }
        public int Age
        {
            get { return _employee.Age; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]string caller = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }
    }
