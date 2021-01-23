    public class CustomMethods
    {
        Employee _employee;
        public CustomMethods(Employee employee)
        {
            _employee = employee;
        }
        public string FullName 
        {
            get 
            {
                return string.Format("{0} {1}", 
                    _employee.FirstName, _employee.LastName); 
            }
        }
    }
    public partial class Employee : Entity
    {
        CustomMethods _customMethods;
        public CustomMethods CustomMethods
        {
            get 
            {
                if (_customMethods == null)
                    _customMethods = new CustomMethods(this);
                return _customMethods;
            }
        }
    }
