    public class ElAppliance : IComparable<ElAppliance>, INotifyPropertyChanged
    {
        string name;
        string company;
        double price;
        public int number = 1;
        bool chBox;
    
        public bool ChBox { get { return this.chBox; } set { this.chBox = value; OnPropertyChanged(nameof(ChBox )); } }
        public string Name { get { return this.name; } }
        public string Company { get { return this.company; } }
        public double Price { get { return this.price; } }
        public int Number { get { return this.number; } set { this.number = value; } }
    
        public ElAppliance(string name, string company, double price)
        {
            this.name = name;
            this.company = company;
            this.price = price;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public int CompareTo(ElAppliance other)
        {
            return this.name.CompareTo(other.name);
        }
        public override string ToString() => ($"Name: {name} | Company : {company} | Price: {price}");
    }
