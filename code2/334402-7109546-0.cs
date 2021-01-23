    public class Person : ObservableObject
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name == value)
                    return;
                name = value;
                RaisePropertyChanged(() => Name);
            }
        }
        private int? age;
        public int? Age
        {
            get { return age; }
            set
            {
                if (age == value)
                    return;
                age = value;
                RaisePropertyChanged(() => Age);
            }
        }
    }
