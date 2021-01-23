    public class EmployeeViewModel : IDataErrorInfo, INotifyPropertyChanged
    {
        public string FirstName { /* get set and NotifyChanged here...*/ }
        public string LastName { /* get set and NotifyChanged here...*/ }
        public string Error
        {
            get { return error; }
        }
     
        public string this[string columnName]
        {
            get 
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case "FirstName":
                        if(string.IsNullOrEmpty(this.FirstName))
                            error = "FirstName can not be blank";
                        else if (this.FirstName == "Ekk")
                            error = "Ekk is my name, you should change!";
                        break;
                    case "LastName":
                        if(string.IsNullOrEmpty(this.LastName))
                            error = "LastName can not be blank";
                        break;
                }
                return error;
            }
        }
    }
