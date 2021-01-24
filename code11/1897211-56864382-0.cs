    public class Student:PropertyChangeBase
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                NotifyPropertyChanged();
            }
        }
        private string fullName;
        public string FullName
        {
            get { return Name + " " + LastName; }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                NotifyPropertyChanged();
            }
        }
    }
