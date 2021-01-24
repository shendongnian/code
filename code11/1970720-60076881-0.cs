    public class ChangesModel : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Facility { get; set; }
        public string Controller { get; set; }
        public string ParameterName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime ChangeDate { get; set; }
        private bool _validated;
        public bool Validated
        {
            get { return _validated; }
            set { _validated = value; NotifyPropertyChanged(); }
        }
        public DateTime ValidationDate { get; set; }
        public event PropertyChangedEventHandler PropertyChanged; 
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
