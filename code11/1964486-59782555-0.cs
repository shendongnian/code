    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Employee> Employees { get; }
            = new ObservableCollection<Employee>();
        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                selectedEmployee = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(Employee)));
            }
        }
    }
