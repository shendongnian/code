    public class Animals: INotifyPropertyChanged
    {
        public int NumberOfElephants { get; set; }
        public int NumberOfMonkeys { get; set; }
        public int TotalAnimals
        {
            get
            {
                return NumberOfElephants + NumberOfMonkeys;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
