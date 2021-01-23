    public class TreeViewModel : INotifyPropertyChanged
    {   
        private List<Department> departments;
        public TreeViewModel()
        {
            Departments = new List<Department>()
            {
                new Department("Department1"),
                new Department("Department2"),
                new Department("Department3")
            };
        }
        public List<Department> Departments
        {
            get
            {
                return departments;
            }
            set
            {
                departments = value;
                OnPropertyChanged("Departments");
            }
        }
     
        public void SomeMethod()
        {
            MessageBox.Show("*****");
        }
    }   
