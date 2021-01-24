     public class ViewModel : INotifyPropertyChanged
        {
    
            #region Constants and Enums
    
            #endregion
    
            #region Private and Protected Member Variables 
            private IList<EmployeeModel> ang1;
            EmployeeModel _selectedEmployee;
            private string numeText;
            #endregion
    
            #region Private and Protected Methods
            private void OnPropertyChanged(string propName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
            #endregion
    
            #region Constructors
            public ViewModel()
            {
                Ang1 = new List<EmployeeModel>();
                Ang1.Add(new EmployeeModel() {  Name="1"});
                Ang1.Add(new EmployeeModel() { Name = "2" });
            }
            #endregion
    
            #region Public Properties
            public IList<EmployeeModel> Ang1
            {
                get
                {
                    return ang1;
                }
                set
                {
                    ang1 = value;
                    OnPropertyChanged(nameof(Ang1));
                }
            }
    
            public EmployeeModel SelectedEmployee
            {
                get
                {
                    return _selectedEmployee;
                }
                set
                {
                    _selectedEmployee = value;
                    NumeText = value.Name;
                    OnPropertyChanged(nameof(SelectedEmployee));
                }
            }
    
            public string NumeText
            {
                get
                {
                    return this.numeText;
                }
                set
                {
    
                    this.numeText = value;
                    OnPropertyChanged(nameof(NumeText));
                }
            }
            #endregion
    
            #region Public Methods
            public event PropertyChangedEventHandler PropertyChanged;
    
            #endregion
    
    
        }
