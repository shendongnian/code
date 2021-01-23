    public partial class MainWindow : Window
    {
        private ReadOnlyObservableCollection<Person> _readOnlyEmp = null;
        private ObservableCollection<Person> _emp = new ObservableCollection<Person>;
        public ReadOnlyObservableCollection<Person> Emp
        {
            if(_readOnlyEmp = null)
                _readOnlyEmp = new ReadOnlyObservableCollection<Person>(_emp);
            return _readOnlyEmp;
        }
        public void AddEmployee(Employee e)
        {
            _emp.Add(e);
        }
        public void RemoveEmployee(Employee e)
        { 
            _emp.Remove(e);
        }
    }
